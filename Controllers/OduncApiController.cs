using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
using KutuphaneUygulamasi.Models;
using KutuphaneUygulamasi.DTO.KitapTur;

namespace KutuphaneUygulamasi.Controllers
{
[ApiController]
[Route("api/Odunc")]
public class OduncApiController : ControllerBase
{
    private readonly KutuphaneDbContext _context;

    public OduncApiController(KutuphaneDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var odunc = _context.Oduncler
            .Include(x => x.Uye)
            .Include(x => x.Kitap)
            .ToList();

        return Ok(odunc);
    }

    [HttpPost]
    public IActionResult Ekle(OduncEkleDto dto)
    {
        Odunc odunc = new Odunc
        {
            UyeId = dto.UyeId,
            KitapId = dto.KitapId,
            GetirmesiIstenenTarih = dto.GetirmesiIstenenTarih
        };

        _context.Oduncler.Add(odunc);
        _context.SaveChanges();

        return Ok(odunc);
    }

    [HttpPut("{id}")]
    public IActionResult Duzenle(int id, OduncDuzenleDto dto)
    {
        var odunc = _context.Oduncler.Find(id);

        if (odunc == null)
            return NotFound();

        odunc.TeslimTarihi = dto.TeslimTarihi;
        odunc.Durum = dto.Durum;

        _context.SaveChanges();

        return Ok(odunc);
    }

    [HttpDelete("{id}")]
    public IActionResult Sil(int id)
    {
        var odunc = _context.Oduncler.Find(id);

        if (odunc == null)
            return NotFound();

        _context.Oduncler.Remove(odunc);
        _context.SaveChanges();

        return Ok();
    }
}
}