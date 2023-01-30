namespace WebMVCnew.webInfrastructure
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string Url, string authorizationtoken = null, string authorizationmethod = "bearer");
        Task<HttpResponseMessage> PostAsync<T>(string Url, T item,string authorizationtoken = null, string authorizationmethod = "bearer");
        Task<HttpResponseMessage> PutAsync<T>(string Url, T item,string authorizationtoken = null, string authorizationmethod = "bearer");
        Task<HttpResponseMessage> DeleteAsync(string Url, string  authorizationtoken = null, string authorizationmethod = "bearer");
    }
}
