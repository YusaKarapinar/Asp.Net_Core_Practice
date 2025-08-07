using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using efcorApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace efcorApp.Controllers
{
    public class KursController : Controller
    {
        private readonly DataContext _context;
        public KursController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var kurslar = await _context.Kurslar.ToListAsync();
            return View(kurslar);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Kurs model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Kurslar.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _context.Kurslar.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
        {

            var kurs = await _context.Kurslar.FindAsync(id);

            if (kurs == null)
            {
                return NotFound();
            }
            _context.Kurslar.Remove(kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kurs = await _context.Kurslar.Include(k => k.KursKayitlar)
                                             .ThenInclude(k => k.Ogrenci)
                                             .FirstOrDefaultAsync(k => k.KursId == id);
            if (kurs == null)
            {
                return NotFound();
            }

            return View(kurs);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Kurs model)
        {

            var kurs = await _context.Kurslar.FindAsync(id);
            if (kurs == null)
            {
                return BadRequest();
            }
            if (kurs.KursId != id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(kurs);
            }
            kurs.KursId = model.KursId;
            kurs.Baslik = model.Baslik;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}