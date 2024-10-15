using Mailo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mailo.IRepo
{
    public interface IAddToCartRepo
    {

        Task<List<Product>> GetProducts(Order order);
        Task<OrderProduct> IsMatched(Order order, int id);
        Task<Order> GetOrders(string id);
        Task<OrderProduct> ExistingCartItem(int productId, string userId);
    }
}
