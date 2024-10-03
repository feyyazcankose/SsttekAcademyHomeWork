namespace SsttekAcademyHomeWork.Models.Repositories.Books
{
    public interface IBookRepository
    {
        List<Book> GetBooks();

        Book GetBook(int id);

        void Add(Book book);

        void Update(Book book);

        void Delete(int id);
    }
}