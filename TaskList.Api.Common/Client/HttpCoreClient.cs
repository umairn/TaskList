using Ofgem.Document.Apis.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Api.Common
{
 public   class HttpCoreClient: IHttpCoreClient
    {
        private HttpClient _client;
     
        public HttpCoreClient()
        {
            
            _client = new HttpClient();
        }



        public async Task<HttpResponseMessage> Post(string requestUri, object value)
             => await Post(requestUri, value, "");

        public async Task<HttpResponseMessage> Post(
            string requestUri, object value, string bearerToken)
        {
            var builder = new HttpRequestBuilder()
                                .AddMethod(HttpMethod.Post)
                                .AddRequestUri(requestUri)
                                .AddContent(new JsonContent(value))
                                .AddBearerToken(bearerToken);

            return await builder.SendAsync();
        }


    }
}
