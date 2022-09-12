using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
   public class Response
    {
        public Response(StatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add(Header.Server, "My Web Server");
            this.Headers.Add(Header.Date, $"{DateTime.UtcNow:r}");
        }

        public StatusCode StatusCode { get; init; } // init is we initialized in the beginning and dont change
                                                    // // the value again(object initializer or ctor ) 

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }
    }
    
}
