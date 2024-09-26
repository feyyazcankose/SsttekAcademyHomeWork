namespace SsttekAcademyHomeWork.Models.Repositories.Books
{
    public interface IBookRepository
    {
        List<Book> GetBooks();

        Book GetBook(int id);
    }
}