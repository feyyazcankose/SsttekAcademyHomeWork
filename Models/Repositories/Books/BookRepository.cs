namespace SsttekAcademyHomeWork.Models.Repositories.Books
{
    public class BookRepository: IBookRepository
    {
        private static List<Book> books = new();

        static BookRepository()
        {
            books.Add(new Book() { Id = 1, Title = "Book 1", Author = "Author 1", PublicationYear = 2000, ISBN = "ISBN 1", Genre = "Genre 1", Publisher = "Publisher 1", PageCount = 100, Language = "Language 1", Summary = "Summary 1", AvailableCopies = 10, ImageUrl = "ImageUrl 1" });
            books.Add(new Book() { Id = 2, Title = "Book 2", Author = "Author 2", PublicationYear = 2001, ISBN = "ISBN 2", Genre = "Genre 2", Publisher = "Publisher 2", PageCount = 200, Language = "Language 2", Summary = "Summary 2", AvailableCopies = 20, ImageUrl = "ImageUrl 2" });
            books.Add(new Book() { Id = 3, Title = "Book 3", Author = "Author 3", PublicationYear = 2002, ISBN = "ISBN 3", Genre = "Genre 3", Publisher = "Publisher 3", PageCount = 300, Language = "Language 3", Summary = "Summary 3", AvailableCopies = 30, ImageUrl = "ImageUrl 3" });
            books.Add(new Book() { Id = 4, Title = "Book 4", Author = "Author 4", PublicationYear = 2003, ISBN = "ISBN 4", Genre = "Genre 4", Publisher = "Publisher 4", PageCount = 400, Language = "Language 4", Summary = "Summary 4", AvailableCopies = 40, ImageUrl = "ImageUrl 4" });
            books.Add(new Book() { Id = 5, Title = "Book 5", Author = "Author 5", PublicationYear = 2004, ISBN = "ISBN 5", Genre = "Genre 5", Publisher = "Publisher 5", PageCount = 500, Language = "Language 5", Summary = "Summary 5", AvailableCopies = 50, ImageUrl = "ImageUrl 5" });
        }

        public List<Book> GetBooks()
        {
            return books;
        }
    }
}