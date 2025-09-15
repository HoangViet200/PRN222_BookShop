using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRN222_BookShop.Services;

namespace PRN222_DreamsCar.Controllers
{
    
    public class BookController : Controller
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        public IActionResult Index(
            int? categoryId,
            List<int> authorId,
            List<int> supplierId,
            List<int> publisherId,
            int? subcategoryId,
            string? keyword,
            int page = 1,
            int pageSize = 5,
            string sortOrder = "all")
        {

            var filter = _bookServices.GetBooksByFilter(categoryId, authorId, supplierId, publisherId, subcategoryId, keyword);


            if (!string.IsNullOrEmpty(sortOrder) && sortOrder != "all")
            {
                filter = sortOrder == "desc"
                    ? filter.OrderByDescending(b => b.UnitPrice).ToList()
                    : filter.OrderBy(b => b.UnitPrice).ToList();
            }

            int totalItems = filter.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var books = filter.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.SortOrder = sortOrder;
            ViewBag.TotalPages = totalPages;
            ViewBag.Keyword = keyword;
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.SelectedSubCategoryId = subcategoryId;
            ViewBag.SelectedAuthorId = authorId;
            ViewBag.SelectedSupplierId = supplierId;
            ViewBag.SelectedPublisherId = publisherId;

            return View(books);
        }


        public IActionResult Detail(int? bookId)
        {
            var bookDetail = _bookServices.GetBookById(bookId); 
            ViewBag.BookDetail = bookDetail;
            var bookList = _bookServices.GetAllBooks();
            return View(bookList);
        }
    }
}
