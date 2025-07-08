using Microsoft.EntityFrameworkCore;
using PRN222_BookShop.Models;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.DA
{
    public class CategoryDASQLServer : ICategoryDA
    {
        private readonly DBContext _context;

        public CategoryDASQLServer(DBContext context)
        {
            _context = context;
        }
        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public List<SubCategory> GetSubCategories(int categoryId)
        {
            return _context.SubCategories.Include(s => s.Category)
                .Where(sc => sc.CategoryID == categoryId)
                .ToList();
        }
    }
}
