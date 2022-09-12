using BasicWebServer.Server;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SoftUniHttpServer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1"); // this is my ip address of the server i create
            var port = 8080; // my port

            var server = new HttpServer("127.0.0.1", port);
            server.Start();


        }

           
        
    }
}
