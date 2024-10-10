using Microsoft.EntityFrameworkCore;
using SsttekAcademyHomeWork.Data;
using SsttekAcademyHomeWork.Models.Entities.Books;

namespace SsttekAcademyHomeWork.Models.Repositories.Books;

public class BookRepositoryWithPostgreSql: GenericRepository<Book>,IBookRepository
{
    public BookRepositoryWithPostgreSql(AppDbContext context) : base(context)
    {
    }
    
}