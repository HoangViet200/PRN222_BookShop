using PRN222_BookShop.Models;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.DA
{
    public class AuthortDASQLServer :IAuthorDA
    {
        private readonly DBContext _context;
        public AuthortDASQLServer(DBContext context)
        {
            _context = context;
        }
        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }
    }

}
