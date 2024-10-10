using Microsoft.EntityFrameworkCore;
using SsttekAcademyHomeWork.Data;
using SsttekAcademyHomeWork.Models.Entities.Books;

namespace SsttekAcademyHomeWork.Models.Repositories.Books;

public class BookRepositoryWithPostgreSql(AppDbContext context):IBookRepository
{
    public List<Book> GetBooks()
    {
       return context.Books.AsNoTracking().ToList();
    }

    public Book GetBook(int id)
    {
       return context.Books.AsNoTracking().FirstOrDefault(x=>x.Id == id);
    }

    public void Add(Book book)
    {
        context.Books.Add(book);
    }

    public void Update(Book book)
    {
        context.Books.Update(book);
    }

    public void Delete(int id)
    {
        var book = GetBook(id); 
       context.Books.Remove(book);
    }
}