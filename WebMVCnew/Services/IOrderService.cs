using WebMVCnew.webModels.OrderModels;
namespace WebMVCnew.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrder(string orderId);
        Task<int> CreateOrder(Order order);
    }
}
