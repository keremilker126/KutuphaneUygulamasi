public class Odunc
{
    public int Id { get; set; }
    
    public int UyeId { get; set; }
    public Uye Uye { get; set; } // Nesne olarak ekledik

    public int KitapId { get; set; }
    public Kitap Kitap { get; set; } // Nesne olarak ekledik

    public DateTime VerilisTarihi { get; set; } = DateTime.Now;
    public DateTime GetirmesiIstenenTarih { get; set; }
    
    // Teslim tarihi başta boş olabilir, o yüzden 'DateTime?' (nullable) yaptık
    public DateTime? TeslimTarihi { get; set; } 
    
    public bool Durum { get; set; } = false;
}