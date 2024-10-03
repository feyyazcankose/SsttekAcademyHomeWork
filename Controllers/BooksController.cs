using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWork.Models.Services.Books;
using SsttekAcademyHomeWork.Models.ViewModels.Books;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBookViewModel createBookViewModel)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(createBookViewModel);
                return RedirectToAction("Index");
            }

            return View(createBookViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var boook = _bookService.GetBook(id);
            return View(new UpdateBookViewModel
            {
                Id = boook.Id,
                Title = boook.Title,
                Author = boook.Author,
                PublicationYear = boook.PublicationYear,
                ISBN = boook.ISBN,
                Genre = boook.Genre,
                Publisher = boook.Publisher,
                PageCount = boook.PageCount,
                Language = boook.Language,
                Summary = boook.Summary,
                AvailableCopies = boook.AvailableCopies,
                ImageUrl = boook.ImageUrl
            });
        }

        [HttpPost]
        public IActionResult Update(UpdateBookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(bookViewModel);
                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }

        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}