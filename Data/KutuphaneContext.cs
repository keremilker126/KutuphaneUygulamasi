using Microsoft.EntityFrameworkCore;

// Veritabanı bağlamı
namespace KutuphaneUygulamasi.Data
{
public class KutuphaneDbContext : DbContext
{

    public KutuphaneDbContext(DbContextOptions<KutuphaneDbContext> options) : base(options)
    {
        
    }


    // DbSet'ler, veritabanındaki tabloları temsil eder
    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }
    public DbSet<YayinEvi> YayinEvleri { get; set; }
    public DbSet<KitapTur> KitapTurleri { get; set; }
    public DbSet<Uye> Uyeler { get; set; }
    public DbSet<Odunc> Oduncler { get; set; }
    public DbSet<Ceza> Cezalilar { get; set; }
    public DbSet<Sinif> Siniflar { get; set; }



}
}