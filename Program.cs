using Microsoft.EntityFrameworkCore;
using SsttekAcademyHomeWork.Data;
using SsttekAcademyHomeWork.Models.Repositories;
using SsttekAcademyHomeWork.Models.Repositories.Products;
using SsttekAcademyHomeWork.Models.Services.Products;
using SsttekAcademyHomeWork.Models.Repositories.Books;
using SsttekAcademyHomeWork.Models.Services.Books;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgreSql");
    x.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IProductRepository, ProductRepository>(); // ProductRepository için DI kaydı
builder.Services.AddScoped<IProductService, ProductService>(); // ProductService için DI kaydı
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // UnitOfWork için DI kaydı
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // GenericRepository için DI kaydı
builder.Services.AddScoped<IBookRepository, BookRepositoryWithPostgreSql>(); // BookRepository için DI kaydı
builder.Services.AddScoped<IBookService, BookService>(); // BookService için DI kaydı

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
