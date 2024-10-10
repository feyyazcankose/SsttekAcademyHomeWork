using SsttekAcademyHomeWork.Data;
using SsttekAcademyHomeWork.Models.Entities.Books;

namespace SsttekAcademyHomeWork.Models.Repositories.Books;

public class BookRepositoryWithPostgreSql(AppDbContext context):IBookRepository
{
    public List<Book> GetBooks()
    {
       return context.Books.ToList();
    }

    public Book GetBook(int id)
    {
       return context.Books.FirstOrDefault(x=>x.Id == id);
    }

    public void Add(Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();
        
    }

    public void Update(Book book)
    {
        context.Books.Update(book);
        context.SaveChanges();
        
    }

    public void Delete(int id)
    {
        var book = GetBook(id); 
       context.Books.Remove(book);
       context.SaveChanges();
    }
}