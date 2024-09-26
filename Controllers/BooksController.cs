using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWork.Models.Services.Books;

namespace SsttekAcademyHomeWork.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetBooks());
        }
        
        public IActionResult Detail(int id)
        {
            return View(_bookService.GetBook(id));
        }
    }
}