using PRN222_BookShop.DA;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IAuthorDA _authorDA;
        public AuthorServices(IAuthorDA authorDA)
        {
            _authorDA = authorDA;
        }
        public List<Author> GetAllAuthors()
        {
            return _authorDA.GetAllAuthors();
        }

    }
}
