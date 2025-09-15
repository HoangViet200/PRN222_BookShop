using PRN222_BookShop.Models;

namespace PRN222_BookShop.Services
{
    public interface IOrderServices
    {
        Order CreateOrder(Order order);
        Order GetOrderById(int orderId);
        List<Order> GetAllOrdersByUser(string userId);
        List<OrderDetail> GetOrderDetails(int orderId);
        void UpdateOrderStatus(int orderId, string status);
        Order UpdateStock(Order order);

        List<Order> GetAllOrders();
    }
}
