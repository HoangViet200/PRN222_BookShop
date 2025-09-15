using PRN222_BookShop.DA;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookDA _bookDA;
        public BookServices(IBookDA bookDA)
        {
            _bookDA = bookDA;
        }
        public List<Book> GetAllBooks()
        {
            return _bookDA.GetAllBooks();
        }

        public Book? GetBookById(int? bookId)
        {
            return _bookDA.GetBookById(bookId);
        }

        public List<Book> GetBooksByFilter(int? categoryId, List<int> authorId, List<int> supplierId, List<int> publisherId, int? subcategoryId, string? keyword)
        {
            return _bookDA.GetBooksByFilter(categoryId, authorId, supplierId, publisherId, subcategoryId, keyword);
        }

        public void UpdateBook(Book book)
        {
            _bookDA.UpdateBook(book);
        }
    }
}
