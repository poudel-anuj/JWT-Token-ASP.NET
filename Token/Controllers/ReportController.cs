using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Token.Result;

namespace Token.Controllers
{
    public class ReportController : ApiController
    {
        [Authorize]
        [Route("api/Report/Get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return new HttpResult(HttpStatusCode.BadRequest, new { message = "Sucessfully Authorized" }, Request);
        }
    }
}
