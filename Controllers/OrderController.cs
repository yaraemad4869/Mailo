﻿using Mailo.Data;
using Mailo.IRepo;
using Mailo.Models;
using Mailo.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Mailo.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAddToCartRepo _order;
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(UserManager<User> userManager, IAddToCartRepo order, IUnitOfWork unitOfWork)
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
            return View(await _order.GetProducts(await _order.GetOrders(user.Id)));
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
            var existingWishlistItem = await _order.ExistingCartItem(id, user.Id);
            //.FirstOrDefaultAsync(w => w.UserId == user.Id && w.ProductId == productId);

            if (existingWishlistItem != null)
            {
                // If the product is already in the wishlist, you may want to return a message
                return BadRequest("Product is already in the wishlist.");
            }

            // Add product to the wishlist
            var wishlistItem = new Wishlist
            {
                UserID = user.Id,
                ProductID = id
            };

            _unitOfWork.wishlists.Insert(wishlistItem);
            TempData["Success"] = "Product Has Been Added Successfully";
            return RedirectToAction("Index");
        }
    }

}
