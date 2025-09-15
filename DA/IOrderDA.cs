using PRN222_BookShop.Models;

namespace PRN222_BookShop.DA
{
    public interface IOrderDA
    {
        Order CreateOrder(Order order);
        Order GetOrderById(int orderId);
        List<Order> GetAllOrdersByUser(string userId);
        List<OrderDetail> GetOrderDetails(int orderId);
        void UpdateOrderStatus(int orderId, string status);

        List<Order> GetAllOrders();
    }
}
