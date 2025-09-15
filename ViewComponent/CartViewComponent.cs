using Microsoft.AspNetCore.Mvc;
using PRN222_BookShop.Services;


    public class CartViewComponent : ViewComponent
    {
        private readonly IShoppingCartService _shoppingCartService;

        public CartViewComponent(IShoppingCartService shoppingCartService)
        {
        _shoppingCartService = shoppingCartService;
        }
        public IViewComponentResult Invoke()
        {
            var cart = _shoppingCartService.GetCart().GetTotalQuantity();
            return View(cart);
        }
    }
