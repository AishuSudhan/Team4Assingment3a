using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System;

namespace WebMVCnew.webInfrastructure
{
    public class HttpClientClass : IHttpClient
    {
        private readonly HttpClient _httpclient;
        public HttpClientClass()
        {
            _httpclient = new HttpClient();
        }
        public async Task<HttpResponseMessage> DeleteAsync(string Url, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, Url);
            if (authorizationtoken != null)
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationmethod,
                    authorizationtoken);
            }
            return await _httpclient.SendAsync(requestMessage);

        }

        public async Task<string> GetAsync(string Url, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, Url);
            if (authorizationtoken != null)
            {
                requestMessage.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationmethod, authorizationtoken);
            }

            var response = await _httpclient.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string Url, T item, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            return await DoPostPutAysnc(HttpMethod.Post, Url, item, authorizationtoken, authorizationmethod);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string Url, T item, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            return await DoPostPutAysnc(HttpMethod.Put, Url, item, authorizationtoken, authorizationmethod);
        }

        private async Task<HttpResponseMessage> DoPostPutAysnc<T>(HttpMethod method, string Url,
           T item, string authorizationtoken, string authorizationmethod)
        {
            var requestMessage = new HttpRequestMessage(method, Url);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item),
                System.Text.Encoding.UTF8, "application/json");
            if (authorizationtoken != null)
            {
                requestMessage.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationmethod, authorizationtoken);
            }
            var response = await _httpclient.SendAsync(requestMessage);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }
            return response;
        }
    }
}
