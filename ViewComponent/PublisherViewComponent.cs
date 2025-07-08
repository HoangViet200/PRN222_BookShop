using Microsoft.AspNetCore.Mvc;
using PRN222_BookShop.Services;
public class PublisherViewComponent : ViewComponent

{
    private readonly IPublisherServices _publisherServices;
    public PublisherViewComponent(IPublisherServices publisherServices)
    {
        _publisherServices = publisherServices;
    }
    public IViewComponentResult Invoke()
    {
        var publishers = _publisherServices.GetAllPublishers();
        return View(publishers);
    }
}

