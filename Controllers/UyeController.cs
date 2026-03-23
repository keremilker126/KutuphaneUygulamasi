using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KutuphaneUygulamasi.Models;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Controllers;

public class UyeController : Controller
{
    private readonly ILogger<UyeController> _logger;
    private readonly KutuphaneDbContext _context;

    public UyeController(ILogger<UyeController> logger, KutuphaneDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var uyeler = await _context.Uyeler.ToListAsync();

        return View(uyeler);
    }
    [HttpGet]
    public async Task<IActionResult> Ekle()
    {
        ViewBag.sinif = await _context.Siniflar.ToListAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(Uye uye)
    {
        if (uye == null)
        {
            return NotFound();
        }
        ViewBag.sinif = await _context.Siniflar.ToListAsync();

        await _context.Uyeler.AddAsync(uye);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }

    public async Task<IActionResult> Sil(int id)
    {

        var uye = await _context.Uyeler.FindAsync(id);
        if (uye == null)
        {
            return NotFound();
        }
        _context.Uyeler.Remove(uye);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }
    [HttpGet]
    public async Task<IActionResult> Duzenle(int id)
    {
        var uye = await _context.Uyeler.FindAsync(id);
        if (uye == null)
        {
            return NotFound();
        }

        ViewBag.sinif = await _context.Siniflar.ToListAsync(); // 🔥 EKLE

        return View(uye);
    }

    [HttpPost]

    public async Task<IActionResult> Duzenle(Uye uye)
    {
        if (uye == null)
        {
            return NotFound();
        }
        _context.Uyeler.Update(uye);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }





}
