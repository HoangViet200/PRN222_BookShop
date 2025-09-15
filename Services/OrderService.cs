using PRN222_BookShop.DA;
using PRN222_BookShop.Models;

namespace PRN222_BookShop.Services
{
    public class OrderService : IOrderServices
    {
        private readonly IOrderDA _orderDASQLServer;
        private readonly IBookDA _bookDA;
        public OrderService(IOrderDA orderDASQLServer, IBookDA bookDA)
        {
            _orderDASQLServer = orderDASQLServer;
            _bookDA = bookDA;
        }
        public Order CreateOrder(Order order)
        {
            return _orderDASQLServer.CreateOrder(order);
        }

        public List<Order> GetAllOrders()
        {
            return _orderDASQLServer.GetAllOrders();
        }

        public List<Order> GetAllOrdersByUser(string userId)
        {
            return _orderDASQLServer.GetAllOrdersByUser(userId);
        }

        public Order GetOrderById(int orderId)
        {
            return _orderDASQLServer.GetOrderById(orderId);
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return _orderDASQLServer.GetOrderDetails(orderId);
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            _orderDASQLServer.UpdateOrderStatus(orderId, status);
        }

        public Order UpdateStock(Order order)
        {
            foreach (var detail in order.OrderDetails)
            {
                var book = _bookDA.GetBookById(detail.BookID);
                if (book != null)
                {
                    book.StockQuantity -= detail.Quantity;
                    _bookDA.UpdateBook(book);
                }
            }
            return _orderDASQLServer.CreateOrder(order);
        }
    }
}