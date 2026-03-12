using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KutuphaneUygulamasi.Models;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
namespace KutuphaneUygulamasi.Controllers;

public class YazarController : Controller
{
    private readonly ILogger<YazarController> _logger;
    private readonly KutuphaneDbContext _context;

    public YazarController(ILogger<YazarController> logger, KutuphaneDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var yazarlar = await _context.Yazarlar.ToListAsync();

        return View(yazarlar);
    }
    [HttpGet]
    public IActionResult Ekle()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Ekle(Yazar yazar)
    {
        if (yazar==null)
        {
            return NotFound();
        }
        await _context.Yazarlar.AddAsync(yazar);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }

    public async Task<IActionResult> Sil(int id)
    {
        var yazar = await _context.Yazarlar.FindAsync(id);
        if (yazar==null)
        {
            return NotFound();
        }
        _context.Yazarlar.Remove(yazar);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
        
    }

    [HttpGet]
    public async Task<IActionResult> Duzenle(int id)
    {
        var yazar = await _context.Yazarlar.FindAsync(id);
        if (yazar==null)
        {
            return NotFound();
        }
        return View(yazar);
    }

    [HttpPost]
    public async Task<IActionResult> Duzenle(Yazar yazar)
    {
        if (yazar != null)
        {
        _context.Update(yazar);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
        }
        return NotFound();
        
    } 

    





}
