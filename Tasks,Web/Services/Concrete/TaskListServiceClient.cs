using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaskList.Api.Common;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace TaskList.Web.Services
{
    public class TaskListServiceClient : ITaskListServiceClient
    {
        private HttpClient _client;
        private IConfiguration _configuration;
        public TaskListServiceClient(IConfiguration configuration, HttpClient client)
        {
            _configuration = configuration;
            _client = client;
        }
        public async Task<TaskResponse> AddTask(TaskItem task)
        {
            var documentResponse = new TaskResponse();
            var baseUri = _configuration.GetSection("TaskServiceBaseUrl").Value;

            var requestUri = $"{baseUri}" + "AddTask/";

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestUri)
            };
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(requestMessage);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                documentResponse = JsonConvert.DeserializeObject<TaskResponse>(responseContent);
                return documentResponse;
            }
            else
            {
                throw new HttpRequestException("Request to Task service failed", new Exception(responseContent));
            }
        }

        public  TaskResponse GetTask(Guid id, [Optional] string name)
        {
            var result = name != null ? "/" + name : null;
            string url = _configuration.GetSection("TaskServiceBaseUrl").Value.ToString() + "GetTask/" + id + result;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(url);

                    return JsonConvert.DeserializeObject<TaskResponse>(response.Result);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + ' ' + e.InnerException.Message + ' ' + url);
            }
        }
    

        public  List<TaskResponse> GetTasks()
        {
            string url = _configuration.GetSection("TaskServiceBaseUrl").Value.ToString() + "GetTasks/";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetStringAsync(url);

                    return JsonConvert.DeserializeObject<List<TaskResponse>>(response.Result);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + ' ' + e.InnerException.Message + ' ' + url);
            }

        }
    }
}
