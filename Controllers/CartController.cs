﻿using Mailo.Data;
using Mailo.Data.Enums;
using Mailo.IRepo;
using Mailo.Models;
using Mailo.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Mailo.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICartRepo _order;
        private readonly IUnitOfWork _unitOfWork;
        public CartController(UserManager<User> userManager, ICartRepo order, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _order = order;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("User not found");
            }
            return View(await _order.GetProducts(await _order.GetOrder(user.Id)));
        }
        public async Task<IActionResult> New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            var existingCartItem = await _order.ExistingCartItem(id, user.Id);

            if (existingCartItem != null)
            {
                return BadRequest("Product is already in the cart.");
            }
            Order o = await _order.GetOrder(user.Id);
             _order.InsertToCart(o.ID, existingCartItem.ProductID);
            
            TempData["Success"] = "Product Has Been Added Successfully";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> NewOrder(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            var existingOrderItem = await _order.GetOrder(user.Id);
            //.FirstOrDefaultAsync(w => w.UserId == user.Id && w.ProductId == productId);

            if (existingOrderItem == null||(existingOrderItem.OrderStatus!=OrderStatus.New))
            {
                // If the product is already in the wishlist, you may want to return a message
                return BadRequest("Cart is already ordered.");
            }
            existingOrderItem.OrderStatus = OrderStatus.Pending;
            existingOrderItem.DeliveryFee = 100;
            TempData["Success"] = "Cart Has Been Ordered Successfully";
            return RedirectToAction("Index");
        }
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteFromCart(int id = 0)
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return Unauthorized();
			}
			var existingCartItem = await _order.ExistingCartItem(id, user.Id);

			if (existingCartItem == null)
			{
				// If the product is already in the wishlist, you may want to return a message
				return BadRequest("Cart is already ordered.");
			}
            _order.DeleteFromCart(existingCartItem.OrderID, existingCartItem.ProductID);

			TempData["Success"] = "Cart Has Been Ordered Successfully";
			return RedirectToAction("Index");

		}
	}

}
