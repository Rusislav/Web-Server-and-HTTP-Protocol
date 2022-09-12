using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;
namespace BasicWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.serverListener = new TcpListener(this.ipAddress, this.port);
        }

        public void Start()
        {
            serverListener.Start();
            Console.WriteLine($"Server start on port {port}");
            Console.WriteLine("Listening for request ");

            while (true) // with the while we can accept many requests
            {
                var connection = serverListener.AcceptTcpClient(); //. Get the connection from the browser 

                var networkStream = connection.GetStream();//return a response from our server to the browser to visualize. To do this,
                                                           //first we need to create a stream, through which data is received or sent to the browser as a byte array

                var requestText = this.ReadRequest(networkStream);
                WriteRespons(networkStream,"Hello From Rusi");

                Console.WriteLine(requestText);

               connection.Close(); //we close the connection to the browser 
            }
        }

        private static void WriteRespons(NetworkStream networkStream ,string content)
        {
            var contentLength = Encoding.UTF8.GetByteCount(content);
            //and get its length in bytes(bytes length is often different from the string length)


            var response = $@"HTTP/1.1 200 OK   
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";  // construct our response

            var responsBytes = Encoding.UTF8.GetBytes(response);//send the content as a plain text with the UTF-8 encoding to accept more symbols 

            networkStream.Write(responsBytes);//send the response bytes to the browser
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLenght = 1024;
            var buffer = new byte[bufferLenght];
            var totalbytes = 0;
            var reguestBuilder = new StringBuilder();

            do // do while we use when we want at least 1 time to loop
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLenght);//read bytes from the network stream
                totalbytes += bytesRead;

                if(totalbytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is to large");
                }

                reguestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));//parse them into a string and append the string to the StringBuilder

            } while (networkStream.DataAvailable);//The loop should be active until there is no more data from the stream

            return reguestBuilder.ToString();
        }
    }

    
}
