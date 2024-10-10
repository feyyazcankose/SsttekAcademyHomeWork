using SsttekAcademyHomeWork.Models.Entities.Books;

namespace SsttekAcademyHomeWork.Models.Repositories.Books
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        IQueryable<Book> GetFilteredBooks(string title, string author, string genre, int? publicationYear, string isbn, string publisher);
    }
}