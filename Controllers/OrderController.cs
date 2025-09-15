using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PRN222_BookShop.Models;
using PRN222_BookShop.Services;

namespace PRN222_BookShop.Controllers
{
    [Authorize(Roles = "User")]
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;
        private readonly UserManager<AppUserModel> _userManager;

        public OrderController(IOrderServices orderServices, UserManager<AppUserModel> userManager)
        {
            _orderServices = orderServices;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var orders = _orderServices.GetAllOrdersByUser(user.Id);
            return View(orders);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var order = _orderServices.GetOrderById(id);
            if (order == null || order.UserId != user.Id)
                return NotFound();

            return View(order);
        }
    }
}