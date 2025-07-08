using PRN222_BookShop.Models;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.DA
{
    public class PublisherDASQLServer : IPublisherDA
    {
        private readonly DBContext _context;
        public PublisherDASQLServer(DBContext context)
        {
            _context = context;
        }
        public List<Publisher> GetAllPublishers()
        {
            return _context.Publishers.ToList();
        }
    }

}
