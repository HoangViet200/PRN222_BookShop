using PRN222_BookShop.DA;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryDA _categoryDA;
        public CategoryServices(ICategoryDA categoryDA)
        {
            _categoryDA = categoryDA;
        }
        public List<Category> GetAllCategories()
        {
            return _categoryDA.GetAllCategories();
        }

        public List<SubCategory> GetSubCategories(int categoryId)
        {
            return _categoryDA.GetSubCategories(categoryId);
        }
    }
}
