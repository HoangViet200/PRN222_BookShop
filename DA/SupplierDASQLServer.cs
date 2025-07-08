using PRN222_BookShop.Models;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.DA
{
    public class SupplierDASQLServer : ISupplierDA
    {
        private readonly DBContext _context;
        public SupplierDASQLServer(DBContext context)
        {
            _context = context;
        }
        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }
    }
}
