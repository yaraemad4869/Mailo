using Mailo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mailo.IRepo
{
    public interface IWishlistRepo
    {
        Task<List<Product>> GetProducts(string id);
        Task<Wishlist> ExistingWishlistItem(int id, string userId);
    }
}
