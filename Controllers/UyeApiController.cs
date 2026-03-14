using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
using KutuphaneUygulamasi.Models;
using KutuphaneUygulamasi.DTO.KitapTur;

namespace KutuphaneUygulamasi.Controllers
{
[ApiController]
[Route("api/Uye")]
public class UyeApiController : ControllerBase
{
    private readonly KutuphaneDbContext _context;

    public UyeApiController(KutuphaneDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Uyeler.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var uye = _context.Uyeler.Find(id);

        if (uye == null)
            return NotFound();

        return Ok(uye);
    }

    [HttpPost]
    public IActionResult Ekle(UyeEkleDto dto)
    {
        Uye uye = new Uye
        {
            Ad = dto.Ad,
            Soyad = dto.Soyad,
            Eposta = dto.Eposta,
            Telefon = dto.Telefon
        };

        _context.Uyeler.Add(uye);
        _context.SaveChanges();

        return Ok(uye);
    }

    [HttpPut("{id}")]
    public IActionResult Duzenle(int id, UyeDuzenleDto dto)
    {
        var uye = _context.Uyeler.Find(id);

        if (uye == null)
            return NotFound();

        uye.Ad = dto.Ad;
        uye.Soyad = dto.Soyad;
        uye.Eposta = dto.Eposta;
        uye.Telefon = dto.Telefon;

        _context.SaveChanges();

        return Ok(uye);
    }

    [HttpDelete("{id}")]
    public IActionResult Sil(int id)
    {
        var uye = _context.Uyeler.Find(id);

        if (uye == null)
            return NotFound();

        _context.Uyeler.Remove(uye);
        _context.SaveChanges();

        return Ok();
    }
}
}