namespace WebMVCnew.webInfrastructure
{
    public interface IHttpClient
    {
        Task<string> GetAsync(string baseUrl, string authorizationtoken = null, string authorizationmethod = "bearer");
        Task<HttpResponseMessage> PostAsync<T>(string baseUrl, T item,string authorizationtoken = null, string authorizationmethod = "bearer");
        Task<HttpResponseMessage> PutAsync<T>(string baseUrl, T item,string authorizationtoken = null, string authorizationmethod = "bearer");
        Task<HttpResponseMessage> DeleteAsync(string baseUrl, string  authorizationtoken = null, string authorizationmethod = "bearer");
    }
}
