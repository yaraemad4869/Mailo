using Mailo.Data;
using Mailo.Data.Enums;
using Mailo.IRepo;
using Mailo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Mailo.Repo
{
    public class AddToCartRepo : IAddToCartRepo
    {
        private readonly AppDbContext _db;
        public AddToCartRepo(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<Product>> GetProducts(Order order)
        {
            return await _db.OrderProducts.Where(op => op.OrderID == order.ID)
                .Select(op => op.product)
                .ToListAsync();
        }
        public async Task<OrderProduct> IsMatched(Order order,int id)
        {
            return await _db.OrderProducts.FirstOrDefaultAsync(op => op.OrderID == order.ID && op.ProductID == id);
        }
        public async Task<Order> GetOrders(string id)
        {
            return await _db.Orders.FirstOrDefaultAsync(o => o.UserID == id && o.OrderStatus == OrderStatus.New);
        }
        public async Task<OrderProduct> ExistingCartItem(int productId, string userId)
        {
            return await IsMatched(await GetOrders(userId),productId);
       }
    }
}

