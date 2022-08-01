using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace Token.Result
{

    public class HttpResult:IHttpActionResult
    {   
        HttpStatusCode _statusCode;
        string _content;
        HttpRequestMessage _httpRequestMessage;

        public HttpResult(HttpStatusCode statusCode, object content, HttpRequestMessage httpRequestMessage)
        {
            _statusCode = statusCode;
            _content = JsonSerializer.Serialize(content);
            _httpRequestMessage = httpRequestMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = _statusCode,
                Content = new StringContent(_content, Encoding.UTF8, "application/json"),
                RequestMessage = _httpRequestMessage
            };
                
            return Task.FromResult(response);
        }

    }

 
}   