
using SsttekAcademyHomeWork.Models.Repositories.Books;
using SsttekAcademyHomeWork.Models.ViewModels.Books;

namespace SsttekAcademyHomeWork.Models.Services.Books
{
    public interface IBookService
    {
        List<BookViewModel> GetBooks();

        BookViewModel GetBook(int id);

        void Add(CreateBookViewModel book);

        void Update(UpdateBookViewModel book);

        void Delete(int id);
    }
}