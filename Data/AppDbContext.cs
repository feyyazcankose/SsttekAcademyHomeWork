using Microsoft.EntityFrameworkCore;
using SsttekAcademyHomeWork.Models.Entities.Books;

namespace SsttekAcademyHomeWork.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { } 
    
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API approach

        // Primary Key
        modelBuilder.Entity<Book>().HasKey(b => b.Id);

        // Property Configurations
        modelBuilder.Entity<Book>()
            .Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(250); // Kitap başlığı için maksimum uzunluk

        modelBuilder.Entity<Book>()
            .Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(50); // Yazar adı için maksimum uzunluk

        modelBuilder.Entity<Book>()
            .Property(b => b.PublicationYear)
            .IsRequired(); // Yayın yılı zorunlu

        modelBuilder.Entity<Book>()
            .Property(b => b.ISBN)
            .IsRequired()
            .HasMaxLength(13); // ISBN numarası için maksimum uzunluk

        modelBuilder.Entity<Book>()
            .Property(b => b.Genre)
            .IsRequired()
            .HasMaxLength(250); // Tür (Roman, Bilim Kurgu vb.) için maksimum uzunluk

        modelBuilder.Entity<Book>()
            .Property(b => b.Publisher)
            .HasMaxLength(250); // Yayınevi için maksimum uzunluk

        modelBuilder.Entity<Book>()
            .Property(b => b.PageCount)
            .IsRequired(); // Sayfa sayısı zorunlu

        // Tablo adı değiştirmek istersen (isteğe bağlı)
        // modelBuilder.Entity<Book>().ToTable("BookTable");

        base.OnModelCreating(modelBuilder);
    }
}