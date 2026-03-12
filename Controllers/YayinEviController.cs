using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KutuphaneUygulamasi.Models;

using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace KutuphaneUygulamasi.Controllers;

public class YayinEviController : Controller
{
    private readonly ILogger<YayinEviController> _logger;
    private readonly KutuphaneDbContext _context;

    public YayinEviController(ILogger<YayinEviController> logger, KutuphaneDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var yayinEvleri = await _context.YayinEvleri.ToListAsync();

        return View(yayinEvleri);
    }
    [HttpGet]
    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Ekle(YayinEvi yayinEvi)
    {
        if (ModelState.IsValid)
        {
            _context.YayinEvleri.Add(yayinEvi);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        
            
        }
        return View(yayinEvi);
    }


    public async Task<IActionResult> Sil(int id)
    {
        var yayinEvi =await _context.YayinEvleri.FindAsync(id);
        if (yayinEvi == null)
        {
            return NotFound();
        }
        _context.YayinEvleri.Remove(yayinEvi);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Duzenle(int id)
    {
        var yayinevi = await _context.YayinEvleri.FindAsync(id);
        if (yayinevi == null){
            return NotFound();
        }
        return View(yayinevi);
    }


    [HttpPost]
    public async Task<IActionResult> Duzenle(YayinEvi yayinEvi)
    {
        if (ModelState.IsValid)
        {
            _context.YayinEvleri.Update(yayinEvi);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(yayinEvi);
    }



}
