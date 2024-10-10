using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWork.Models.Services.Books;
using SsttekAcademyHomeWork.Models.ViewModels.Books;
using System.Threading.Tasks;

namespace SsttekAcademyHomeWork.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooks();
            return View(books);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var book = await _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookViewModel createBookViewModel)
        {
            if (ModelState.IsValid)
            {
                await _bookService.Add(createBookViewModel);
                return RedirectToAction("Index");
            }

            return View(createBookViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var book = await _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(new UpdateBookViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublicationYear = book.PublicationYear,
                ISBN = book.ISBN,
                Genre = book.Genre,
                Publisher = book.Publisher,
                PageCount = book.PageCount,
                Language = book.Language,
                Summary = book.Summary,
                AvailableCopies = book.AvailableCopies,
                ImageUrl = book.ImageUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                await _bookService.Update(bookViewModel);
                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            await _bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
