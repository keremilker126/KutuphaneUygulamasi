using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
using KutuphaneUygulamasi.Models;
using KutuphaneUygulamasi.DTO.KitapTur;

namespace KutuphaneUygulamasi.Controllers
{
   [ApiController]
[Route("api/Ceza")]
public class CezaApiController : ControllerBase
{
    private readonly KutuphaneDbContext _context;

    public CezaApiController(KutuphaneDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var cezalar = _context.Cezalilar
            .Include(x => x.Odunc)
            .ToList();

        return Ok(cezalar);
    }

    [HttpPost]
    public IActionResult Ekle(CezaEkleDto dto)
    {
        Ceza ceza = new Ceza
        {
            OduncId = dto.OduncId,
            Tutar = dto.Tutar,
            Aciklama = dto.Aciklama
        };

        _context.Cezalilar.Add(ceza);
        _context.SaveChanges();

        return Ok(ceza);
    }

    [HttpPut("{id}")]
    public IActionResult Duzenle(int id, CezaDuzenleDto dto)
    {
        var ceza = _context.Cezalilar.Find(id);

        if (ceza == null)
            return NotFound();

        ceza.OdendiMi = dto.OdendiMi;

        _context.SaveChanges();

        return Ok(ceza);
    }

    [HttpDelete("{id}")]
    public IActionResult Sil(int id)
    {
        var ceza = _context.Cezalilar.Find(id);

        if (ceza == null)
            return NotFound();

        _context.Cezalilar.Remove(ceza);
        _context.SaveChanges();

        return Ok();
    }
}
}