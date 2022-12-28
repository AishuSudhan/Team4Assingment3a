namespace WebMVCnew.webInfrastructure
{
    public class HttpClientClass : IHttpClient
    {
        private readonly HttpClient _httpclient;
        public HttpClientClass()
        {
            _httpclient = new HttpClient();
        }
        public Task<HttpResponseMessage> DeleteAsync(string baseUrl, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAsync(string baseUrl, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);
            var response = await _httpclient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        public Task<HttpResponseMessage> PostAsync<T>(string baseUrl, T item, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync<T>(string baseUrl, T item, string authorizationtoken = null, string authorizationmethod = "bearer")
        {
            throw new NotImplementedException();
        }
    }
}
