using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PRN222_BookShop.Models;
using PRN222_BookShop.Services;

namespace PRN222_BookShop.Controllers
{
    [Authorize(Roles = "User")]
    public class CheckoutController : Controller
    {
        private readonly IShoppingCartService _cartService;
        private readonly IOrderServices _orderServices;
        private readonly UserManager<AppUserModel> _userManager;
        private readonly IBookServices _bookServices;

        public CheckoutController(IShoppingCartService cartService, IOrderServices orderServices, UserManager<AppUserModel> userManager, IBookServices bookServices)
        {
            _cartService = cartService;
            _orderServices = orderServices;
            _userManager = userManager;
            _bookServices = bookServices;
        }

        public IActionResult Index()
        {
            return View(_cartService.GetCart());
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(string shippingAddress)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var cart = _cartService.GetCart();
            if (!cart.Items.Any())
                return RedirectToAction("Index", "Cart");

            foreach (var item in cart.Items)
            {
                var book = _bookServices.GetBookById(item.BookID);
                if (book == null || book.StockQuantity < item.Quantity)
                {
                    TempData["Error"] = $"Sản phẩm {item.BookName} không đủ số lượng.";
                    return RedirectToAction("Index", "Cart");
                }
            }

            var order = new Order
            {
                UserId = user.Id,
                TotalAmount = cart.GetTotalPrice(),
                ShippingAddress = shippingAddress,
                Status = "Process",
                OrderDetails = cart.Items.Select(item => new OrderDetail
                {
                    BookID = item.BookID,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            _orderServices.UpdateStock(order);
            _cartService.ClearCart();

            return RedirectToAction("OrderSuccess", new { id = order.OrderID });
        }

        public IActionResult OrderSuccess(int id)
        {
            ViewBag.OrderID = id;
            return View();
        }
        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = _orderServices.GetAllOrdersByUser(user.Id);
            return View(orders);
        }
        public async Task<IActionResult> OrderDetail(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var order = _orderServices.GetOrderById(id);
            return View(order);
        }
    }
    }