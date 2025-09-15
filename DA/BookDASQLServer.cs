using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PRN222_BookShop.Models;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.DA
{
    public class BookDASQLServer : IBookDA
    {
        private readonly DBContext _context;
        public BookDASQLServer(DBContext context)
        {
            _context = context;
        }
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book? GetBookById(int? bookId)
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Supplier).Include(b => b.Publisher).FirstOrDefault(b => b.BookID == bookId);
        }

        public List<Book> GetBooksByFilter(int? categoryId, List<int> authorId, List<int> supplierId, List<int> publisherId, int? subcategoryId, string? keyword)
        {
            return _context.Books.Include(b => b.Category)
                .Include(b => b.SubCategory)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.Supplier)
                .Where(b =>
                (!categoryId.HasValue || categoryId == 0 || b.CategoryID == categoryId) &&
                (!subcategoryId.HasValue || subcategoryId == 0 || b.SubCategoryID == subcategoryId) &&
                (authorId == null || authorId.Contains(b.AuthorID) || authorId.Count == 0) &&
                (supplierId == null || supplierId.Contains(b.SupplierID) || supplierId.Count == 0) &&
                (publisherId == null || publisherId.Contains(b.PublisherID) || publisherId.Count == 0) &&
                (keyword.IsNullOrEmpty() || b.Name.ToLower().Contains(keyword.ToLower()) || b.ISBN.ToLower().Contains(keyword.ToLower()))
                ).ToList();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
