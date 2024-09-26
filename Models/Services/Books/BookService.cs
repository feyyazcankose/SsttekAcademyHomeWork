using SsttekAcademyHomeWork.Models.Repositories.Books;

namespace SsttekAcademyHomeWork.Models.Services.Books
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }
    }
}