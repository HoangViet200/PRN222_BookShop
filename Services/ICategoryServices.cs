using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.Services
{
    public interface ICategoryServices
    {
        List<Category> GetAllCategories();

        List<SubCategory> GetSubCategories(int categoryId);
    }
}
