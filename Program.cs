using KutuphaneUygulamasi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        // JSON serialization ayarları: camelCase property isimleri
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        // Gerekirse indentation ekle (development için)
        options.JsonSerializerOptions.WriteIndented = builder.Environment.IsDevelopment();
    });

// CORS yapılandırması: Tüm origin'lere izin ver (geliştirme için)
builder.Services.AddCors(options =>
{
    options.AddPolicy("abc", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Veritabanı bağlantısı için DbContext'i ekleyin
builder.Services.AddDbContext<KutuphaneDbContext>(options =>
    options.UseSqlite("Data Source=Kutuphane.db"));
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

// CORS middleware'ini ekle
app.UseCors("abc");

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
