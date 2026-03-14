using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
using KutuphaneUygulamasi.Models;
using KutuphaneUygulamasi.DTO.KitapTur;

namespace KutuphaneUygulamasi.Controllers
{
    [ApiController]
[Route("api/Yazar")]
public class YazarApiController : ControllerBase
{
    private readonly KutuphaneDbContext _context;

    public YazarApiController(KutuphaneDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Yazarlar.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var yazar = _context.Yazarlar.Find(id);

        if (yazar == null)
            return NotFound();

        return Ok(yazar);
    }

    [HttpPost]
    public IActionResult Ekle(YazarEkleDto dto)
    {
        Yazar yazar = new Yazar
        {
            Ad = dto.Ad,
            Soyad = dto.Soyad,
            Biyografi = dto.Biyografi
        };

        _context.Yazarlar.Add(yazar);
        _context.SaveChanges();

        return Ok(yazar);
    }

    [HttpPut("{id}")]
    public IActionResult Duzenle(int id, YazarDuzenleDto dto)
    {
        var yazar = _context.Yazarlar.Find(id);

        if (yazar == null)
            return NotFound();

        yazar.Ad = dto.Ad;
        yazar.Soyad = dto.Soyad;
        yazar.Biyografi = dto.Biyografi;

        _context.SaveChanges();

        return Ok(yazar);
    }

    [HttpDelete("{id}")]
    public IActionResult Sil(int id)
    {
        var yazar = _context.Yazarlar.Find(id);

        if (yazar == null)
            return NotFound();

        _context.Yazarlar.Remove(yazar);
        _context.SaveChanges();

        return Ok();
    }
}
}