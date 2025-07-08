using PRN222_BookShop.DA;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.Services
{
    public class SupplierServices : ISupplierServices
    {
        private readonly ISupplierDA _supplierDA;
        public SupplierServices(ISupplierDA supplierDA)
        {
            _supplierDA = supplierDA;
        }
        public List<Supplier> GetAllSuppliers()
        {
            return _supplierDA.GetAllSuppliers();
        }
    }
}
