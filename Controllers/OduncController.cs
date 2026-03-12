using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KutuphaneUygulamasi.Models;
using Microsoft.EntityFrameworkCore;
using KutuphaneUygulamasi.Data;

namespace KutuphaneUygulamasi.Controllers;

public class OduncController : Controller
{
    private readonly ILogger<OduncController> _logger;
    private readonly KutuphaneDbContext _context;

    public OduncController(ILogger<OduncController> logger, KutuphaneDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var oduncler = await _context.Oduncler.ToListAsync();
        

        return View(oduncler);

    }
    [HttpGet]
    public async Task<IActionResult> KitapVer()
    {
        ViewBag.Kitaplar = await _context.Kitaplar.ToListAsync();
        ViewBag.Uyeler = await _context.Uyeler.ToListAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> KitapVer(Odunc odunc)
    {
        odunc.VerilisTarihi = DateTime.Now;
        odunc.TeslimTarihi = null;
        odunc.Durum = false;
        if(odunc==null){
            return NotFound();
        }
        await _context.Oduncler.AddAsync(odunc);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }




    public async Task<IActionResult> Sil(int id)
    {
        var odunc = await _context.Oduncler.FindAsync(id);
        if (odunc == null)
        {
            return NotFound();
        }

        _context.Oduncler.Remove(odunc);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    

    public async Task<IActionResult> KitabiAl(int id)
    {

        var odunc = await _context.Oduncler.FindAsync(id);
        if(odunc==null){
            return NotFound();
        }
        odunc.TeslimTarihi = DateTime.Now;
        odunc.Durum = true;
        _context.Oduncler.Update(odunc);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
        

        
    }






}
