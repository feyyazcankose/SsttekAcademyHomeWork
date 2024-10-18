using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWork.Models.Services.Books;
using SsttekAcademyHomeWork.Models.ViewModels.Books;
using SsttekAcademyHomeWork.Models.Commons; // ServiceResult için
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SsttekAcademyHomeWork.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string title, string author, string genre, int? publicationYear, string isbn, string publisher)
        {
            var result = await _bookService.GetFilteredBooksAsync(title, author, genre, publicationYear, isbn, publisher);

            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View("Error");
            }

            return View(result.Data);
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookService.GetBooks();

            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View("Error");
            }

            return View(result.Data);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await _bookService.GetBook(id);

            if (!result.Success)
            {
                return NotFound();
            }

            return View(result.Data);
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
                var result = await _bookService.Add(createBookViewModel);

                if (!result.Success)
                {
                    ModelState.AddModelError("", result.Message);
                    return View(createBookViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(createBookViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _bookService.GetBook(id);

            if (!result.Success)
            {
                return NotFound();
            }

            var book = result.Data;

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
                var result = await _bookService.Update(bookViewModel);

                if (!result.Success)
                {
                    ModelState.AddModelError("", result.Message);
                    return View(bookViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.GetBook(id);

            if (!result.Success)
            {
                return NotFound();
            }

            var deleteResult = await _bookService.Delete(id);

            if (!deleteResult.Success)
            {
                ModelState.AddModelError("", deleteResult.Message);
                return View("Error");
            }

            return RedirectToAction("Index");
        }
    }
}
