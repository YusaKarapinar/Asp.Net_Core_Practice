using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using efcorApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace efcorApp.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly DataContext _context;
        public KursKayitController(DataContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var kayıt = await _context.KursKayitlar.Include(k => k.Ogrenci).Include(k => k.Kurs).ToListAsync();
            return View(kayıt);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId", "OgrenciAd");
            ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Baslik");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(KursKayit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.KayitTarihi = DateTime.Now; // Set the registration date to now
            _context.KursKayitlar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _context.KursKayitlar.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int KayitId,int id)
        {
            var model = await _context.KursKayitlar.FindAsync(KayitId);
            if (model == null)
            {
                return NotFound();
            }
            _context.KursKayitlar.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}