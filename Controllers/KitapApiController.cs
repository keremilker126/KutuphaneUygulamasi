using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
using KutuphaneUygulamasi.Models;
using KutuphaneUygulamasi.DTO.KitapTur;

namespace KutuphaneUygulamasi.Controllers
{
[ApiController]
[Route("api/Kitap")]
public class KitapApiController : ControllerBase
{
    private readonly KutuphaneDbContext _context;

    public KitapApiController(KutuphaneDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var kitaplar = _context.Kitaplar.ToList();
        return Ok(kitaplar);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var kitap = _context.Kitaplar.Find(id);
        return Ok(kitap);
    }

    [HttpPost]
    public IActionResult Ekle(KitapEkleDto dto)
    {
        Kitap kitap = new Kitap
        {
            Ad = dto.Ad,
            ISBN = dto.ISBN,
            SayfaSayisi = dto.SayfaSayisi,
            YazarId = dto.YazarId,
            YayinEviId = dto.YayinEviId,
            TurId = dto.TurId
        };

        _context.Kitaplar.Add(kitap);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Duzenle(int id, KitapDuzenleDto dto)
    {
        var kitap = _context.Kitaplar.Find(id);

        kitap.Ad = dto.Ad;
        kitap.ISBN = dto.ISBN;
        kitap.SayfaSayisi = dto.SayfaSayisi;

        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Sil(int id)
    {
        var kitap = _context.Kitaplar.Find(id);

        _context.Kitaplar.Remove(kitap);
        _context.SaveChanges();

        return Ok();
    }
}

    
}