using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SecureWebApiByMessageHandler.Handlers
{
    public class APIKeyMessageHandler : DelegatingHandler
    {
        private const string APIKey = "ZG95b3Vrbm93dGhhdGFjZXJpc3RoZWJlc3Rjb21wYW55aW50aGV3b3JsZGJ5YW5keQ==";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            bool validKey = false;
            IEnumerable<string> requestHeaders;
            var checkApoKeyExists = request.Headers.TryGetValues("APIKey", out requestHeaders);
            if (checkApoKeyExists)
            {
                if (requestHeaders.FirstOrDefault().Equals(APIKey))
                {
                    validKey = true;
                }

            }


            if (!validKey)
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new { message = "Invalid API Key" })),
                    ReasonPhrase = "Invalid API Key"
                };
            }

            var response = await base.SendAsync(request, cancellationToken);
            return response;


        }

    }
}