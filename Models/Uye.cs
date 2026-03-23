public class Uye
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public string? SinifAdi { get; set; }
    public string Eposta { get; set; } = string.Empty;
    public string Telefon { get; set; } = string.Empty;
    public DateTime KayitTarihi { get; set; } = DateTime.Now;
}