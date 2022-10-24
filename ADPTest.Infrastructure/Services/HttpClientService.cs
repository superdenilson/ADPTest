using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ADPTest.Infrastructure.Services
{
    public abstract class HttpClientService
    {
        protected string? _baseUrl;
        protected readonly HttpClient _httpClient = new HttpClient();
        private string UrlSerializeObject(object obj)
        {
            var keyValues = obj.GetType().GetProperties()
                .ToList()
                .Select(p => $"{p.Name}={p.GetValue(obj)}")
                .ToArray();
            return string.Join("&", keyValues);
        }

        public Task SendRequest(HttpMethod httpMethod, string url)
        {
            return SendRequest("",httpMethod,url);
        }

        public Task SendRequest(object requestData, HttpMethod httpMethod, string url)
        {
            var requestString = JsonConvert.SerializeObject(requestData);
            return SendRequest(requestString, httpMethod, url);
        }
        public async Task<TResponse> SendRequest<TResponse>(object requestData, HttpMethod httpMethod, string url, bool urlSerialize = false)
        {
            var requestString = urlSerialize ? UrlSerializeObject(requestData) : JsonConvert.SerializeObject(requestData);
            var responseString = await SendRequest(requestString, httpMethod, url); // JsonConvert.DeserializeObject<TResponse>(responseString);
            var responseData = JsonConvert.DeserializeObject<TResponse>(responseString);
            return responseData; ;
        }

        public async Task<string> SendRequest(object requestData, HttpMethod httpMethod, string url, bool urlSerialize = false)
        {
            var requestString = urlSerialize ? UrlSerializeObject(requestData) : JsonConvert.SerializeObject(requestData);
            var responseString = await SendRequest(requestString, httpMethod, url); // JsonConvert.DeserializeObject<TResponse>(responseString);
            return responseString;
        }
        public async Task<TResponse> SendRequest<TResponse>(HttpMethod httpMethod, string url)
        {
            var responseString = await SendRequest("", httpMethod, url);
            var responseData = JsonConvert.DeserializeObject<TResponse>(responseString);
            return responseData;
        }
        public async Task<string> SendRequest(string requestString, HttpMethod httpMethod, string url, string mediaType = "application/json")
        {
            using (HttpRequestMessage request = new HttpRequestMessage(httpMethod, _baseUrl + url))
            {
                request.Headers.Add("Accept", mediaType);

                if (!string.IsNullOrEmpty(requestString))
                {
                    var requestContent = new StringContent(requestString,encoding: Encoding.UTF8,mediaType);
                    request.Content = requestContent;
                }

                using(var response = await _httpClient.SendAsync(request))
                {
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new HttpClientServiceException(responseString);
                    }
                    else if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        throw new HttpClientServiceException(responseString);
                    }

                    return responseString;
                }
            }
        }
    }

    public class HttpClientServiceException: Exception
    {
        public HttpClientServiceException(string? message): base(message) { }
    }
}
