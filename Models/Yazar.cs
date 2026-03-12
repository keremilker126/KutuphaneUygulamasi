public class Yazar
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public string Biyografi { get; set; } = string.Empty;
    
    // Yazarın kitaplarına kolayca ulaşmak için:
    public ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
}