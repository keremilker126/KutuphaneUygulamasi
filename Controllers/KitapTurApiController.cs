using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
using KutuphaneUygulamasi.Models;
using KutuphaneUygulamasi.DTO.KitapTur;

namespace KutuphaneUygulamasi.Controllers
{
    [Route("api/KitapTur")]
    [ApiController]
    public class KitapTurApiController : ControllerBase
    {
        private readonly KutuphaneDbContext _context;

        public KitapTurApiController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // 📚 TÜM TÜRLERİ LİSTELE
        [HttpGet]
        public async Task<ActionResult<List<KitapTurDTO>>> GetAll()
        {
            var turler = await _context.KitapTurleri
                .Select(x => new KitapTurDTO
                {
                    Id = x.Id,
                    Ad = x.Ad
                })
                .ToListAsync();

            return Ok(turler);
        }

        // 📖 TEK TÜR GETİR
        [HttpGet("{id}")]
        public async Task<ActionResult<KitapTurDTO>> GetById(int id)
        {
            var tur = await _context.KitapTurleri.FindAsync(id);

            if (tur == null)
                return NotFound();

            var dto = new KitapTurDTO
            {
                Id = tur.Id,
                Ad = tur.Ad
            };

            return Ok(dto);
        }

        // ➕ YENİ TÜR EKLE
        [HttpPost]
        public async Task<ActionResult> Create(KitapTurEkleDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tur = new KitapTur
            {
                Ad = dto.Ad
            };

            _context.KitapTurleri.Add(tur);
            await _context.SaveChangesAsync();

            return Ok("Tür başarıyla eklendi");
        }

        // ✏️ TÜR GÜNCELLE
        [HttpPut("{id}")]
        public async Task<ActionResult> Duzenle(int id, KitapTurDuzenleDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var tur = await _context.KitapTurleri.FindAsync(id);

            if (tur == null)
                return NotFound();

            tur.Ad = dto.Ad;

            await _context.SaveChangesAsync();

            return Ok("Tür güncellendi");
        }

        // ❌ TÜR SİL
        [HttpDelete("{id}")]
        public async Task<ActionResult> Sil(int id)
        {
            var tur = await _context.KitapTurleri.FindAsync(id);

            if (tur == null)
                return NotFound();

            _context.KitapTurleri.Remove(tur);
            await _context.SaveChangesAsync();

            return Ok("Tür silindi");
        }
    }
}