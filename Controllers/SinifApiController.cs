using KutuphaneUygulamasi.Data;
using KutuphaneUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/Sinif")]
[ApiController]
public class SinifApiController : ControllerBase
{
    private readonly KutuphaneDbContext _context;

    public SinifApiController(KutuphaneDbContext context)
    {
        _context = context;
    }

    // GET: api/SinifApi
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var siniflar = await _context.Siniflar.ToListAsync();
        return Ok(siniflar);
    }

    // GET: api/SinifApi/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var sinif = await _context.Siniflar.FindAsync(id);

        if (sinif == null)
            return NotFound();

        return Ok(sinif);
    }

    // POST: api/SinifApi
    [HttpPost]
    public async Task<IActionResult> Ekle(Sinif sinif)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Siniflar.Add(sinif);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = sinif.Id }, sinif);
    }

    // PUT: api/SinifApi/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Duzenle(int id, Sinif sinif)
    {
        if (id != sinif.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Entry(sinif).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/SinifApi/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Sil(int id)
    {
        var sinif = await _context.Siniflar.FindAsync(id);

        if (sinif == null)
            return NotFound();

        _context.Siniflar.Remove(sinif);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}