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
        foreach (var kitapAlan in await _context.Oduncler.ToListAsync())
        {
            
            TimeSpan fark;
            fark = kitapAlan.TeslimTarihi.Value - kitapAlan.GetirmesiIstenenTarih;
            if (fark.TotalDays>0)
            {
                
                Ceza cezali =new Ceza();
                cezali.OduncId= kitapAlan.Id;
                cezali.Tutar=200;
                cezali.OdendiMi=false;
                cezali.Aciklama = $"kişi kitabı getirilmesi gereken {kitapAlan.GetirmesiIstenenTarih} tarihte getrimeyip {kitapAlan.TeslimTarihi} tarihte getirmiştir bu yuzden {cezali.Tutar}TL para cezasına tabi tutulmuştur";
                await _context.Cezalilar.AddAsync(cezali);
                await _context.SaveChangesAsync();
                
            }

            
        }

        var cezalilar = await _context.Cezalilar.ToListAsync();

        return View(cezalilar);
    }
    public async Task<IActionResult> CezayiBitir(int id)
    {
        var cezali=await _context.Cezalilar.FindAsync(id);
        if (cezali==null)
        {
            return NotFound();
        }
        _context.Cezalilar.Remove(cezali);
        await _context.SaveChangesAsync();
        return View();
    }


}
