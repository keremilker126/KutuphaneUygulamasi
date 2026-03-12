public class KitapTur
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();// Türün kitaplarına kolayca ulaşmak için bir sutun oluşturmaz, sadece ilişkisel olarak kullanılır.
}