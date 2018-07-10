using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Api.Common
{
   public interface IHttpCoreClient
    {

        Task<HttpResponseMessage> Post(string requestUri, object value);
        Task<HttpResponseMessage> Post(
           string requestUri, object value, string bearerToken);
    }
}
