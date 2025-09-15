using PRN222_BookShop.Models;

namespace PRN222_BookShop.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart GetCart();
        void AddToCart(int bookId, int quantity);
        void UpdateCart(int bookId, int quantity);
        void RemoveFromCart(int bookId);
        void ClearCart();
    }
}
