using System.ComponentModel.DataAnnotations;

public class Kitap
{
    public int Id { get; set; }
    
    [Required, StringLength(150)]
    public string Ad { get; set; } = string.Empty;

    // ISBN-13 ve tireler için 13-17 karakter idealdir.
    [StringLength(17)] 
    public string ISBN { get; set; } = string.Empty;
    
    public int SayfaSayisi { get; set; }

    // İlişkiler (Foreign Keys)
    public int YayinEviId { get; set; }
    public YayinEvi? YayinEvi { get; set; }

    public int YazarId { get; set; }
    public Yazar? Yazar { get; set; }

    public int TurId { get; set; } 
    public KitapTur? Tur { get; set; }
}