using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN222_BookShop.DA;
using PRN222_BookShop.Services;

namespace PRN222_BookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeAdminController : Controller
    {
        private readonly IOrderServices _orderServices;

        public HomeAdminController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public IActionResult Index()
        {
            var orders = _orderServices.GetAllOrders();
            return View(orders);
        }

        public IActionResult Detail(int id)
        {
            var order = _orderServices.GetOrderById(id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        public IActionResult Confirm(int id)
        {
            _orderServices.UpdateOrderStatus(id, "Completed");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cancel(int id)
        {
            _orderServices.UpdateOrderStatus(id, "Cancelled");
            return RedirectToAction("Index");
        }
    }
}