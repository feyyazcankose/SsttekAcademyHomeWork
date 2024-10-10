using SsttekAcademyHomeWork.Models.Entities.Books;

namespace SsttekAcademyHomeWork.Models.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        private static readonly List<Book> books = new();

        static BookRepository()
        {
            books.Add(new Book() { Id = 1, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960, ISBN = "978-0060935467", Genre = "Fiction", Publisher = "J.B. Lippincott & Co.", PageCount = 324, Language = "English", Summary = "A novel about the serious issues of rape and racial inequality, told through the eyes of a young girl.", AvailableCopies = 5, ImageUrl = "https://example.com/tokillamockingbird.jpg" });
            books.Add(new Book() { Id = 2, Title = "1984", Author = "George Orwell", PublicationYear = 1949, ISBN = "978-0451524935", Genre = "Dystopian", Publisher = "Secker & Warburg", PageCount = 328, Language = "English", Summary = "A dystopian novel that explores the dangers of totalitarianism and extreme political ideology.", AvailableCopies = 7, ImageUrl = "https://example.com/1984.jpg" });
            books.Add(new Book() { Id = 3, Title = "Pride and Prejudice", Author = "Jane Austen", PublicationYear = 1813, ISBN = "978-1503290563", Genre = "Classic", Publisher = "T. Egerton, Whitehall", PageCount = 279, Language = "English", Summary = "A romantic novel that critiques the British landed gentry at the end of the 18th century.", AvailableCopies = 3, ImageUrl = "https://example.com/prideandprejudice.jpg" });
            books.Add(new Book() { Id = 4, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925, ISBN = "978-0743273565", Genre = "Classic", Publisher = "Charles Scribner's Sons", PageCount = 180, Language = "English", Summary = "A novel about the American dream and the disillusionment of post-war America.", AvailableCopies = 4, ImageUrl = "https://example.com/thegreatgatsby.jpg" });
            books.Add(new Book() { Id = 5, Title = "Moby Dick", Author = "Herman Melville", PublicationYear = 1851, ISBN = "978-1503280786", Genre = "Adventure", Publisher = "Harper & Brothers", PageCount = 635, Language = "English", Summary = "A detailed and symbolic narrative of Captain Ahab's obsessive quest to kill the white whale, Moby Dick.", AvailableCopies = 6, ImageUrl = "https://example.com/mobydick.jpg" });
        }


        public List<Book> GetBooks()
        {
            return books;
        }

        public Book? GetBook(int id)
        {
            var findBook = books.FirstOrDefault(b => b.Id == id);
            if (findBook == null)
            {
                throw new Exception("Book not found");
            }
            return findBook;
        }

        public void Add(Book book)
        {
            book.Id = books.Max((b) => b.Id) + 1;
            books.Add(book);
        }

        public void Update(Book book)
        {
            var findBook = GetBook(book.Id);
            if (findBook == null)
            {
                throw new Exception("Book not found");
            }

            findBook.Title = book?.Title ?? findBook.Title;
            findBook.Author = book?.Author;
            findBook.PublicationYear = book?.PublicationYear ?? findBook.PublicationYear;
            findBook.ISBN = book?.ISBN ?? findBook.ISBN;
            findBook.Genre = book?.Genre ?? findBook.Genre;
            findBook.Genre = book?.Genre ?? findBook.Genre;
            findBook.Publisher = book?.Publisher ?? findBook.Publisher;
            findBook.PageCount = book?.PageCount ?? findBook.PageCount;
            findBook.Language = book?.Language ?? findBook.Language;
            findBook.Summary = book?.Summary ?? findBook.Summary;
            findBook.AvailableCopies = book?.AvailableCopies ?? findBook.AvailableCopies;
            findBook.AvailableCopies = book?.AvailableCopies ?? findBook.AvailableCopies;
            findBook.ImageUrl = book?.ImageUrl ?? findBook.ImageUrl;
        }

        public void Delete(int id)
        {
            var findBook = GetBook(id);
            if (findBook != null)
            {
                books.Remove(findBook);
            }
        }
    }
}