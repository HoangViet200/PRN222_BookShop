using PRN222_BookShop.Models;
using PRN222_BookShop.Extensions;
namespace PRN222_BookShop.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly DBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CART_KEY = "CART_SESSION";

        public ShoppingCartService(DBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext!.Session;

        public ShoppingCart GetCart()
        {
            var cart = Session.GetObject<ShoppingCart>(CART_KEY);
            if (cart == null)
            {
                cart = new ShoppingCart(new List<ShoppingCart.ShoppingCartItem>());
                Session.SetObject(CART_KEY, cart);
            }
            return cart;
        }

        public void AddToCart(int bookId, int quantity)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookID == bookId);
            if (book == null) return;

            var cart = GetCart();
            var item = new ShoppingCart.ShoppingCartItem
            {
                BookID = book.BookID,
                BookName = book.Name,
                CategoryName = book.Category?.Name,
                Price = book.UnitPrice,
                ImageUrl = book.ImageUrl
            };
            cart.AddToCart(item, quantity);

            Session.SetObject(CART_KEY, cart);
        }

        public void UpdateCart(int bookId, int quantity)
        {
            var cart = GetCart();
            cart.UpdateCartItem(bookId, quantity);
            Session.SetObject(CART_KEY, cart);
        }

        public void RemoveFromCart(int bookId)
        {
            var cart = GetCart();
            cart.RemoveFromCart(bookId);
            Session.SetObject(CART_KEY, cart);
        }

        public void ClearCart()
        {
            Session.Remove(CART_KEY);
        }
    }
}