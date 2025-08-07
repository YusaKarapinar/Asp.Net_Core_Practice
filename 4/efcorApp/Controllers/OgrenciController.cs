using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using efcorApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace efcorApp.Controllers
{
    public class OgrenciController : Controller
    {

        private readonly DataContext _context;
        public OgrenciController(DataContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context
                                        .Ogrenciler
                                        .ToListAsync();
            return View(ogrenciler);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
            if (!ModelState.IsValid)
            {
                return (View(model));
            }
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");



        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                var model = await _context.Ogrenciler
                              .Include(k => k.KursKayitlar)
                              .ThenInclude(k => k.Kurs)
                              .FirstOrDefaultAsync(o => o.OgrenciId == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Ogrenci model)
        {
            var ogrenci = await _context.Ogrenciler
                                    
                                        .FirstOrDefaultAsync(k=>k.OgrenciId == id);

            if (ogrenci == null)
            {
                return NotFound();
            }

            if (id != model.OgrenciId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {

                ogrenci.OgrenciAd = model.OgrenciAd;
                ogrenci.OgrenciSoyad = model.OgrenciSoyad;
                ogrenci.OgrenciEmail = model.OgrenciEmail;
                ogrenci.OgrenciTelefon = model.OgrenciTelefon;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
        {
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}