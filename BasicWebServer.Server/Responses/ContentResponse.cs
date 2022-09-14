using BasicWebServer.Server.Common;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Responses
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content , string contentType,Action<Request,Response> preRenderAction = null) 
            : base(StatusCode.OK)
        {
            Guard.AgaintsNull(content);
            Guard.AgaintsNull(contentType);

            this.PreRenderAction = preRenderAction;

            this.Headers.Add(Header.ContentType, contentType);

            this.Body = content;
            
        }

        public override string ToString()
        {

            if(this.Body != null)
            {
                var contendLenght = Encoding.UTF8.GetByteCount(this.Body).ToString();
                this.Headers.Add(Header.ContentLength, contendLenght);
            }
            return base.ToString();
        }
    }
}
