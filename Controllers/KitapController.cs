using Microsoft.AspNetCore.Mvc;
using KutuphaneUygulamasi.Models;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
namespace KutuphaneUygulamasi.Controllers;


public class KitapController : Controller
{
    private readonly ILogger<KitapController> _logger;
    private readonly KutuphaneDbContext _context;

    public KitapController(ILogger<KitapController> logger, KutuphaneDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var kitaplar = await _context.Kitaplar.ToListAsync();

        return View(kitaplar);
        
    }

    [HttpGet]
    public async Task<IActionResult> Ekle()
    {
        ViewBag.YayinEvleri = await _context.YayinEvleri.ToListAsync();
        ViewBag.Yazarlar = await _context.Yazarlar.ToListAsync();
        ViewBag.Turler = await _context.KitapTurleri.ToListAsync();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(Kitap kitap)
    {
        if (ModelState.IsValid)
        {
            _context.Kitaplar.Add(kitap);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        ViewBag.YayinEvleri = await _context.YayinEvleri.ToListAsync();
        ViewBag.Yazarlar = await _context.Yazarlar.ToListAsync();
        ViewBag.Turler = await _context.KitapTurleri.ToListAsync();
        return View(kitap);
    }

    public async Task<IActionResult> Sil(int id){
        var kitap = await _context.Kitaplar.FindAsync(id);
        if(kitap == null){
            return NotFound();
        }
        _context.Kitaplar.Remove(kitap);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Duzenle(int id){
        var kitap = await _context.Kitaplar.FindAsync(id);
        if(kitap == null){
            return NotFound();
        }
        ViewBag.YayinEvleri = await _context.YayinEvleri.ToListAsync();
        ViewBag.Yazarlar = await _context.Yazarlar.ToListAsync();
        ViewBag.Turler = await _context.KitapTurleri.ToListAsync();
        return View(kitap);
    }

    [HttpPost]
    public async Task<IActionResult> Duzenle(Kitap kitap){
        if(ModelState.IsValid){
            _context.Kitaplar.Update(kitap);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        ViewBag.YayinEvleri = await _context.YayinEvleri.ToListAsync();
        ViewBag.Yazarlar = await _context.Yazarlar.ToListAsync();
        ViewBag.Turler = await _context.KitapTurleri.ToListAsync();
        return View(kitap);
    }






}
