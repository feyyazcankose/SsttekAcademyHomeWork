using SsttekAcademyHomeWork.Models.Entities.Books;
using SsttekAcademyHomeWork.Models.ViewModels.Books;
using SsttekAcademyHomeWork.Models.Commons;

namespace SsttekAcademyHomeWork.Models.Services.Books
{
    public interface IBookService
    {
        Task<ServiceResult<List<BookViewModel>>> GetFilteredBooksAsync(
            string title, string author, string genre, int? publicationYear, string isbn, string publisher);

        Task<ServiceResult<List<BookViewModel>>> GetBooks();

        Task<ServiceResult<BookViewModel>> GetBook(int id);

        Task<ServiceResult> Add(CreateBookViewModel book);

        Task<ServiceResult> Update(UpdateBookViewModel book);

        Task<ServiceResult> Delete(int id);
    }
}