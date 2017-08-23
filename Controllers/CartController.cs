using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Board_game_sleeves.Models;
using Board_game_sleeves.ViewModel;
using Board_game_sleeves.Infrastructure.Binders;
namespace Board_game_sleeves.Controllers
{
    public class CartController : Controller
    {
        private bgs db = new bgs();

        [ChildActionOnly]
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Index(string returnUrl,Cart cart)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }


        public RedirectToRouteResult AddToCart(int productId, string returnUrl, Cart cart)
        {
            Product product = db.Products.FirstOrDefault(p => p.ProductId ==
           productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new
            {
                returnUrl
            });
        }
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl, Cart cart)
        {
            Product product = db.Products
            .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveItem(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
