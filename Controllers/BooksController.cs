using Microsoft.AspNetCore.Mvc;

namespace SsttekAcademyHomeWork.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}