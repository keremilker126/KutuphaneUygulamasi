using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KutuphaneUygulamasi.Models;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;


namespace KutuphaneUygulamasi.Controllers;
public class KitapTurController : Controller
{
    private readonly ILogger<KitapTurController> _logger;
    private readonly KutuphaneDbContext _context;

    public KitapTurController(ILogger<KitapTurController> logger, KutuphaneDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var kitapTurleri = await _context.KitapTurleri.ToListAsync();
        return View(kitapTurleri);
    }

    [HttpGet]
    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(KitapTur tur)
    {
        if (ModelState.IsValid)
        {
            _context.KitapTurleri.Add(tur);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(tur);
    }

    public async Task<IActionResult> Sil(int id)
    {
        var tur = await _context.KitapTurleri.FindAsync(id);
        if (tur == null)
        {
            return NotFound();
        }
        _context.KitapTurleri.Remove(tur);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Duzenle(int id)
    {
        var tur = await _context.KitapTurleri.FindAsync(id);
        if (tur == null)
        {
            return NotFound();
        }
        return View(tur);
        
    }

    [HttpPost]
    public async Task<IActionResult> Duzenle(KitapTur tur)
    {
        if (ModelState.IsValid)
        {
            _context.KitapTurleri.Update(tur);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(tur);
    }

}




