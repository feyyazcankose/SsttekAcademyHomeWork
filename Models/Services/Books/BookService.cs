using SsttekAcademyHomeWork.Models.Entities.Books;
using SsttekAcademyHomeWork.Models.Repositories.Books;
using SsttekAcademyHomeWork.Models.ViewModels.Books;

namespace SsttekAcademyHomeWork.Models.Services.Books
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<BookViewModel> GetBooks()
        {
            var bookViewModels = new List<BookViewModel>();
            var books = _bookRepository.GetBooks();

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

        public BookViewModel GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            return new BookViewModel{
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
            } ;
        }

        public void Add(CreateBookViewModel book)
        {
            _bookRepository.Add(new Book
            {
                Title = book.Title,
                Author = book.Author,
                PublicationYear = book.PublicationYear.Value,
                ISBN = book.ISBN,
                Genre = book.Genre,
                Publisher = book.Publisher,
                PageCount = book.PageCount.Value,
                Language = book.Language,
                Summary = book.Summary,
                AvailableCopies = book.AvailableCopies.Value,
                ImageUrl = book.ImageUrl
            });
        }

         public void Update(UpdateBookViewModel bookViewModel)
        {
            var book = _bookRepository.GetBook(bookViewModel.Id);

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
        }


        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}