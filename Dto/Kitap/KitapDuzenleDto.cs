public class KitapDuzenleDto
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public string ISBN { get; set; }
    public int SayfaSayisi { get; set; }

    public int YazarId { get; set; }
    public int YayinEviId { get; set; }
    public int TurId { get; set; }
}