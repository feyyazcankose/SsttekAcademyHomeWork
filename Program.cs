using Microsoft.AspNetCore.Identity;
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
// Add IHttpContextAccessor to the DI container
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(x =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgreSql");
    x.UseNpgsql(connectionString);
});

// Identity servislerini ekleme ve kimlik doğrulama yollarını özelleştirme
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = true;      // Şifre için rakam gereksinimi
        options.Password.RequireLowercase = true;  // Küçük harf gereksinimi
        options.Password.RequireUppercase = true;  // Büyük harf gereksinimi
        options.Password.RequireNonAlphanumeric = false;  // Özel karakter gereksinimi yok
        options.Password.RequiredLength = 6;       // Minimum şifre uzunluğu
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Kimlik doğrulama için cookie yapılandırması
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login"; // Giriş sayfası
    options.AccessDeniedPath = "/Auth/AccessDenied"; // Yetkisiz erişim
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturum süresi
    options.SlidingExpiration = true; // Süre uzatılması
});


builder.Services.AddScoped<IProductRepository, ProductRepository>(); // ProductRepository için DI kaydı
builder.Services.AddScoped<IProductService, ProductService>(); // ProductService için DI kaydı
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // UnitOfWork için DI kaydı
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // GenericRepository için DI kaydı
builder.Services.AddScoped<IBookRepository, BookRepositoryWithPostgreSql>(); // BookRepository için DI kaydı
builder.Services.AddScoped<IBookService, BookService>(); // BookService için DI kaydı

var app = builder.Build();
var scope = app.Services.CreateScope();

AppDbInitialize.InitializeRoles(scope.ServiceProvider);

app.UseAuthentication();
app.UseAuthorization(); 

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
