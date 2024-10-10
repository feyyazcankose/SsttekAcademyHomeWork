
using SsttekAcademyHomeWork.Models.Repositories.Books;
using SsttekAcademyHomeWork.Models.ViewModels.Books;

namespace SsttekAcademyHomeWork.Models.Services.Books
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetBooks();

        Task<BookViewModel> GetBook(int id);

        Task Add(CreateBookViewModel book);

        Task Update(UpdateBookViewModel book);

        Task Delete(int id);
    }
}