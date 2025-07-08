namespace PRN222_BookShop.ViewComponent;
using Microsoft.AspNetCore.Mvc;
using PRN222_BookShop.Services;

public class CategoryViewComponent : ViewComponent
{
    private readonly ICategoryServices _categoryServices;
    public CategoryViewComponent(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }
    public IViewComponentResult Invoke()
    {
        var categories = _categoryServices.GetAllCategories();
        foreach (var cat in categories)
        {
            cat.SubCategories = _categoryServices.GetSubCategories(cat.CategoryID);
        }
        return View(categories);
    }
}
