using PRN222_BookShop.Services;
using Microsoft.AspNetCore.Mvc;


public class AuthorViewComponent : ViewComponent
{
    private readonly IAuthorServices _authorServices;
    public AuthorViewComponent(IAuthorServices authorServices)
    {
        _authorServices = authorServices;
    }
    public IViewComponentResult Invoke()
    {
        var authors = _authorServices.GetAllAuthors();
        return View(authors);
    }
}


