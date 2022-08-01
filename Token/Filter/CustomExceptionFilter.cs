using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Token.Filter
{
    public class CustomExceptionFilter: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string errMsg = string.Empty;

            var exceptionType = actionExecutedContext.Exception.GetType();


            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                errMsg = "Unauthorized Access";
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NullReferenceException))
            {
                errMsg = "Data not found";
                //statusCode = HttpStatusCode.NotFound;
                statusCode = HttpStatusCode.InternalServerError;
            }
            else
            {
                errMsg = "Contact to Admin";
                statusCode = HttpStatusCode.InternalServerError;
            }
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(errMsg),
                ReasonPhrase = "From Exception Filter"
            };

            actionExecutedContext.Response = response;
            base.OnException(actionExecutedContext);
        }

    }
}