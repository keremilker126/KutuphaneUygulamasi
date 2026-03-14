using System.ComponentModel.DataAnnotations;

namespace KutuphaneUygulamasi.DTO.KitapTur
{
    public class KitapTurDuzenleDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tür adı boş bırakılamaz")]
        public string Ad { get; set; } = string.Empty;
    }
}