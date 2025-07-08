using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.DA
{
    public interface ICategoryDA
    {
        List<Category> GetAllCategories();

        List<SubCategory> GetSubCategories(int categoryId);
    }
}
