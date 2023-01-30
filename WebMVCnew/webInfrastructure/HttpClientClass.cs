using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WebMVCnew.webInfrastructure
{
    public class HttpClientClass : IHttpClient
    {
        private readonly HttpClient _httpclient;
        public HttpClientClass()
        {
            _httpclient = new HttpClient();
        }
        public async Task<HttpResponseMessage> DeleteAsync(string Uri, 
            string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, Uri);
            if (authorizationtoken != null)
            {
                request.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationmethod, authorizationtoken);
            }
            return await _httpclient.SendAsync(request);
        }

        public async Task<string> GetStringAsync(string Uri, 
            string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Uri);
            if (authorizationtoken != null)
            {
                request.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationmethod, authorizationtoken);
            }
            var response = await _httpclient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string Uri, T item, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            return await DoPostPutAysnc(HttpMethod.Post, Uri, item, authorizationtoken, authorizationmethod);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string Uri, T item, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            return await DoPostPutAysnc(HttpMethod.Post, Uri, item, authorizationtoken, authorizationmethod);
        }

        private async Task<HttpResponseMessage> DoPostPutAysnc<T>(HttpMethod method, string uri,
            T item, string authorizationToken, string authorizationMethod)
        {
            var requestMessage = new HttpRequestMessage(method, uri);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item),
                System.Text.Encoding.UTF8, "application/json");
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new
                    AuthenticationHeaderValue(authorizationMethod, authorizationToken);
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
