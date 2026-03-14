using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
using KutuphaneUygulamasi.Models;
using KutuphaneUygulamasi.DTO.KitapTur;

namespace KutuphaneUygulamasi.Controllers
{
   [ApiController]
[Route("api/YayinEvi")]
public class YayinEviApiController : ControllerBase
{
    private readonly KutuphaneDbContext _context;

    public YayinEviApiController(KutuphaneDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.YayinEvleri.ToList());
    }

    [HttpPost]
    public IActionResult Ekle(YayinEviEkleDto dto)
    {
        YayinEvi yayin = new YayinEvi
        {
            Ad = dto.Ad,
            Adres = dto.Adres
        };

        _context.YayinEvleri.Add(yayin);
        _context.SaveChanges();

        return Ok(yayin);
    }

    [HttpPut("{id}")]
    public IActionResult Duzenle(int id, YayinEviDuzenleDto dto)
    {
        var yayin = _context.YayinEvleri.Find(id);

        if (yayin == null)
            return NotFound();

        yayin.Ad = dto.Ad;
        yayin.Adres = dto.Adres;

        _context.SaveChanges();

        return Ok(yayin);
    }

    [HttpDelete("{id}")]
    public IActionResult Sil(int id)
    {
        var yayin = _context.YayinEvleri.Find(id);

        if (yayin == null)
            return NotFound();

        _context.YayinEvleri.Remove(yayin);
        _context.SaveChanges();

        return Ok();
    }
}
}