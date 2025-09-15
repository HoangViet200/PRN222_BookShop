using Microsoft.EntityFrameworkCore;
using PRN222_BookShop.Models;

namespace PRN222_BookShop.DA
{
    public class OrderDASQLServer : IOrderDA
    {
        private readonly DBContext _context;
        public OrderDASQLServer(DBContext context)
        {
            _context = context;
        }
        public Order CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public List<Order> GetAllOrdersByUser(string userId)
        {
            return _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Book)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Book)
                .FirstOrDefault(o => o.OrderID == orderId);
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return _context.OrderDetails
                .Include(od => od.Book)
                .Where(od => od.OrderID == orderId)
                .ToList();
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order != null)
            {
                order.Status = status;
                _context.SaveChanges();
            }
        }
    }
}
