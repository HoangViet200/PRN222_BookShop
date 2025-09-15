using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PRN222_BookShop.Services;


namespace PRN222_BookShop.Controllers
{    public class CartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public CartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            return View(_shoppingCartService.GetCart());
        }

        [HttpPost]
        public IActionResult AddToCartAjax(int bookId, int quantity = 1)
        {
            _shoppingCartService.AddToCart(bookId, quantity);
            var totalItems = _shoppingCartService.GetCart().GetTotalQuantity();
            return Json(new { success = true, totalItems = totalItems });
        }


        [HttpPost]
        public IActionResult AddToCart(int bookId, int quantity = 1)
        {
            _shoppingCartService.AddToCart(bookId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCart(int bookId, int quantity)
        {
            _shoppingCartService.UpdateCart(bookId, quantity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int bookId)
        {
            _shoppingCartService.RemoveFromCart(bookId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            _shoppingCartService.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
