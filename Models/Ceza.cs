public class Ceza
{
    public int Id { get; set; }
    
    // Hangi işlemden dolayı ceza kesildi?
    public int OduncId { get; set; } 
    public Odunc Odunc { get; set; }
    
    // Ceza miktarı (Para veya puan)
    public decimal Tutar { get; set; }
    
    // Ceza sebebi (Gecikme, hasar, kayıp vb.)
    public string Aciklama { get; set; } = string.Empty;
    
    // Ceza ödendi mi?
    public bool OdendiMi { get; set; } = false;
}