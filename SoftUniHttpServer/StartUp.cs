using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SoftUniHttpServer
{
    public class StartUp
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
       Name: <input type='text' name='Name'/>
       Age: <input type='number' name ='Age'/>
    <input type='submit' value ='Save' />
    </form>";


        static void Main(string[] args)
            => new HttpServer(routes => routes
           .MapGet("/", new TextResponse("Hello from server!"))
           .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
           .MapGet("/HTML", new HtmlResponse(HtmlForm))
            .MapPost("/HTML", new TextResponse("",StartUp.AddFormDataAction)))
            .Start();


        private static  void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var (key , value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }
        //var ipAddress = IPAddress.Parse("127.0.0.1"); // this is my ip address of the server i create
        //var port = 8080; // my port

        //var server = new HttpServer("127.0.0.1", port);
        //server.Start();






    }
}
