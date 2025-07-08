using Microsoft.AspNetCore.Mvc;
using PRN222_BookShop.Services;
public class SupplierViewComponent : ViewComponent
{
    private readonly ISupplierServices _supplierServices;

    public SupplierViewComponent(ISupplierServices supplierServices)
    {
        _supplierServices = supplierServices;
    }

    public IViewComponentResult Invoke()
    {
        var suppliers = _supplierServices.GetAllSuppliers();
        return View(suppliers);

    }
}

