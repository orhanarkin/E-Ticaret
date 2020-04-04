using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaret.Business.Abstract;
using ETicaret.WebUI.Identity;
using ETicaret.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<ApplicationUser> _userManager;
        public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            { 
                CartId = cart.Id,
                CartItems = cart.SepetUrunleri.Select(i => new CartItemModel()
                { 
                    SepetUrunleriId  = i.Id,
                    UrunId = i.Urun.Id,
                    UrunAdi = i.Urun.UrunAdi,
                    Fiyat = i.Urun.Fiyat,
                    Resim1 = i.Urun.Resim1,
                    Miktar = i.Miktar
                }).ToList()
            });
        }
        [HttpPost]
        public IActionResult AddToCart(int productId,int miktar)
        {
            _cartService.AddToCart(_userManager.GetUserId(User), productId, miktar);
            return Redirect("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            _cartService.DeleteFromCart(_userManager.GetUserId(User), productId);
            return Redirect("Index");
        }
    }
}