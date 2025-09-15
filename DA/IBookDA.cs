using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.DA
{
    public interface IBookDA
    {
        List<Book> GetAllBooks();

        List<Book> GetBooksByFilter(int? categoryId,List<int> authorId, List<int> supplierId, List<int> publisherId, int? subcategoryId, string? keyword);

        Book? GetBookById(int? bookId);

        void UpdateBook(Book book);

    }
}
