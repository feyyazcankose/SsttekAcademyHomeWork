using SsttekAcademyHomeWork.Data;
using SsttekAcademyHomeWork.Models.Entities.Books;
using SsttekAcademyHomeWork.Models.Repositories;
using SsttekAcademyHomeWork.Models.ViewModels.Books;

namespace SsttekAcademyHomeWork.Models.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Book> _bookRepository;

        public BookService(IGenericRepository<Book> bookRepository,IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BookViewModel>> GetBooks()
        {
            var bookViewModels = new List<BookViewModel>();
            var books = await _bookRepository.GetAllAsync();

            foreach (var book in books)
            {
                bookViewModels.Add(new BookViewModel
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

            return bookViewModels;
        }

        public async Task<BookViewModel> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return null;

            return new BookViewModel
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
            };
        }

        public async Task Add(CreateBookViewModel bookViewModel)
        {
            var book = new Book
            {
                Title = bookViewModel.Title,
                Author = bookViewModel.Author,
                PublicationYear = bookViewModel.PublicationYear.Value,
                ISBN = bookViewModel.ISBN,
                Genre = bookViewModel.Genre,
                Publisher = bookViewModel.Publisher,
                PageCount = bookViewModel.PageCount.Value,
                Language = bookViewModel.Language,
                Summary = bookViewModel.Summary,
                AvailableCopies = bookViewModel.AvailableCopies.Value,
                ImageUrl = bookViewModel.ImageUrl
            };

            await _bookRepository.AddAsync(book);
            _unitOfWork.Commit(); // Asenkron commit
        }

        public async Task Update(UpdateBookViewModel bookViewModel)
        {
            var book = await _bookRepository.GetByIdAsync(bookViewModel.Id);
            if (book == null) return;

            book.Title = bookViewModel.Title;
            book.Author = bookViewModel.Author;
            book.PublicationYear = bookViewModel.PublicationYear.Value;
            book.ISBN = bookViewModel.ISBN;
            book.Genre = bookViewModel.Genre;
            book.Publisher = bookViewModel.Publisher;
            book.PageCount = bookViewModel.PageCount.Value;
            book.Language = bookViewModel.Language;
            book.Summary = bookViewModel.Summary;
            book.AvailableCopies = bookViewModel.AvailableCopies.Value;
            book.ImageUrl = bookViewModel.ImageUrl;

            _bookRepository.Update(book);
            _unitOfWork.Commit();  // Asenkron commit
        }

        public async Task Delete(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return;

            _bookRepository.Delete(book);
            _unitOfWork.Commit();  // Asenkron commit
        }
    }
}
