using WebMVCnew.webModels.EventOrderModels;
//using static WebMVCnew.webInfrastructure.APIUrlPaths;

namespace WebMVCnew.Services
{
    public interface IEventOrderService
    {
        Task<EventOrder> GetOrder(string orderId);
        Task<int> CreateOrder(EventOrder order);
    }
}
