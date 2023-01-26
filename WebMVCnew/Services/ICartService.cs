using WebMVCnew.webModels;
using WebMVCnew.webModels.CartModels;

namespace WebMVCnew.Services
{
    public interface ICartService
    {
        Task<Cart> GetCart(ApplicationUser user);
        Task AddItemToCart(ApplicationUser user, CartItem product);
        Task<Cart> UpdateCart(Cart Cart);
        Task<Cart> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities);
        
        Task ClearCart(ApplicationUser user);
    }
}
