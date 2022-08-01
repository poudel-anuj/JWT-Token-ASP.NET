using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Token.Result
{
    public class ChallangeOnUthorizatizedResult:IHttpActionResult
    {
        public ChallangeOnUthorizatizedResult(AuthenticationHeaderValue challange, IHttpActionResult innerResult)
        {
            Challenge = challange;
            InnerResult = innerResult;
        }
        public AuthenticationHeaderValue Challenge { get; private set; }
        public IHttpActionResult InnerResult { get; private set; }


        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage  resp  = await InnerResult.ExecuteAsync(cancellationToken);
            if (resp.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (!resp.Headers.WwwAuthenticate.Any((h) => h.Scheme == Challenge.Scheme))
                {
                    resp.Headers.WwwAuthenticate.Add(Challenge);
                }
            }
            return resp;
        }
    }
}