
using SsttekAcademyHomeWork.Models.Entities.Books;
using SsttekAcademyHomeWork.Models.Repositories.Books;
using SsttekAcademyHomeWork.Models.ViewModels.Books;

namespace SsttekAcademyHomeWork.Models.Services.Books
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetFilteredBooksAsync(string title, string author, string genre, int? publicationYear,
            string isbn, string publisher);
        Task<List<BookViewModel>> GetBooks();

        Task<BookViewModel> GetBook(int id);

        Task Add(CreateBookViewModel book);

        Task Update(UpdateBookViewModel book);

        Task Delete(int id);
    }
}