using KutuphaneUygulamasi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Models; // Modelinin olduğu namespace'i yazmalısın

public class SinifController : Controller
{
    private readonly KutuphaneDbContext _context;

    public SinifController(KutuphaneDbContext context)
    {
        _context = context;
    }

    // LISTELEME: Tüm sınıfları görürüz
    public async Task<IActionResult> Index()
    {
        var siniflar = await _context.Siniflar.ToListAsync();
        return View(siniflar);
    }

    // EKLEME: Formu gösterir
    public IActionResult Ekle()
    {
        return View();
    }

    // EKLEME: Formdan gelen veriyi kaydeder
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Ekle(Sinif sinif)
    {
        if (ModelState.IsValid)
        {
            _context.Add(sinif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(sinif);
    }

    // DÜZENLEME: Mevcut veriyi forma getirir
    public async Task<IActionResult> Duzenle(int? id)
    {
        if (id == null) return NotFound();
        var sinif = await _context.Siniflar.FindAsync(id);
        if (sinif == null) return NotFound();
        return View(sinif);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Duzenle(int id, Sinif sinif)
    {
        if (id != sinif.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(sinif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(sinif);
    }

    // SİLME
    public async Task<IActionResult> Sil(int? id)
    {
        var silinecek = await _context.Siniflar.FindAsync(id);
        if (silinecek==null)
        {
            return NotFound();
        }
        _context.Siniflar.Remove(silinecek);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

}