
using SsttekAcademyHomeWork.Models.Repositories.Books;

namespace SsttekAcademyHomeWork.Models.Services.Books
{
    public interface IBookService
    {
        List<Book> GetBooks();

        Book GetBook(int id);
    }
}