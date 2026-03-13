using System.ComponentModel.DataAnnotations;

namespace KutuphaneUygulamasi.DTO.KitapTur
{
    public class KitapTurEkleDTO
    {
        [Required(ErrorMessage = "Tür adı boş bırakılamaz")]
        public string Ad { get; set; } = string.Empty;
    }
}