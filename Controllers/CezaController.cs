using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KutuphaneUygulamasi.Models;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
namespace KutuphaneUygulamasi.Controllers;

public class CezaController : Controller
{
    private readonly ILogger<CezaController> _logger;
    private readonly KutuphaneDbContext _context;

    public CezaController(ILogger<CezaController> logger, KutuphaneDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        int tutar=350;
        // Teslim edilmemiş kitaplar için ceza kontrolü (duplicate önlemek için)
        var teslimEdilmeyenler = await _context.Oduncler
            .Where(o => o.TeslimTarihi == null && o.GetirmesiIstenenTarih < DateTime.Now)
            .ToListAsync();

        foreach (var kitapAlan in teslimEdilmeyenler)
        {
            // Zaten ceza kesilmiş mi kontrol et
            bool cezaVarMi = await _context.Cezalilar.AnyAsync(c => c.OduncId == kitapAlan.Id);
            if (!cezaVarMi)
            {
                TimeSpan fark = DateTime.Now - kitapAlan.GetirmesiIstenenTarih;
                if (fark.TotalDays > 0)
                {
                    Ceza cezali = new Ceza
                    {
                        OduncId = kitapAlan.Id,
                        Tutar = tutar,
                        OdendiMi = false,
                        Aciklama = $"Kitap getirilmesi gereken {kitapAlan.GetirmesiIstenenTarih:dd/MM/yyyy} tarihinde getirilmemiş. {tutar} TL ceza kesilmiştir."
                    };
                    await _context.Cezalilar.AddAsync(cezali);
                }
            }
        }
        await _context.SaveChangesAsync();

        // Cezaları listele (detaylar için Include ekle)
        var cezalilar = await _context.Cezalilar
            .Include(c => c.Odunc)
                .ThenInclude(o => o.Uye)
            .Include(c => c.Odunc)
                .ThenInclude(o => o.Kitap)
            .ToListAsync();

        return View(cezalilar);
    }
    public async Task<IActionResult> CezayiBitir(int id)
    {

        var cezali = await _context.Cezalilar.FindAsync(id);
        if (cezali == null)
        {
            return NotFound();
        }
        cezali.OdendiMi = true;
        _context.Cezalilar.Update(cezali);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Aciklama(string aciklama)
    {
        ViewBag.Aciklama = aciklama;
        return View();
    }


}
