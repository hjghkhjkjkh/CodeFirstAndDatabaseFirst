using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DATABASE_FIRST.Models;

namespace DATABASE_FIRST.Controllers
{
    public class SinhviensController : Controller
    {
        private readonly SinhviensContext _context;

        public SinhviensController(SinhviensContext context)
        {
            _context = context;
        }

        // GET: Sinhviens
        public async Task<IActionResult> Index()
        {
            var sinhviensContext = _context.Sinhviens.Include(s => s.MakhoaNavigation).Include(s => s.MalopNavigation);
            return View(await sinhviensContext.ToListAsync());
        }

        // GET: Sinhviens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhviens
                .Include(s => s.MakhoaNavigation)
                .Include(s => s.MalopNavigation)
                .FirstOrDefaultAsync(m => m.Masv == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // GET: Sinhviens/Create
        public IActionResult Create()
        {
            ViewData["Makhoa"] = new SelectList(_context.Khoas, "Makhoa", "Makhoa");
            ViewData["Malop"] = new SelectList(_context.Lops, "Malop", "Malop");
            return View();
        }

        // POST: Sinhviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masv,Hoten,Makhoa,Malop,Dob")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makhoa"] = new SelectList(_context.Khoas, "Makhoa", "Makhoa", sinhvien.Makhoa);
            ViewData["Malop"] = new SelectList(_context.Lops, "Malop", "Malop", sinhvien.Malop);
            return View(sinhvien);
        }

        // GET: Sinhviens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhviens.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            ViewData["Makhoa"] = new SelectList(_context.Khoas, "Makhoa", "Makhoa", sinhvien.Makhoa);
            ViewData["Malop"] = new SelectList(_context.Lops, "Malop", "Malop", sinhvien.Malop);
            return View(sinhvien);
        }

        // POST: Sinhviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Masv,Hoten,Makhoa,Malop,Dob")] Sinhvien sinhvien)
        {
            if (id != sinhvien.Masv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhvienExists(sinhvien.Masv))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makhoa"] = new SelectList(_context.Khoas, "Makhoa", "Makhoa", sinhvien.Makhoa);
            ViewData["Malop"] = new SelectList(_context.Lops, "Malop", "Malop", sinhvien.Malop);
            return View(sinhvien);
        }

        // GET: Sinhviens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhviens
                .Include(s => s.MakhoaNavigation)
                .Include(s => s.MalopNavigation)
                .FirstOrDefaultAsync(m => m.Masv == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // POST: Sinhviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhvien = await _context.Sinhviens.FindAsync(id);
            if (sinhvien != null)
            {
                _context.Sinhviens.Remove(sinhvien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhvienExists(string id)
        {
            return _context.Sinhviens.Any(e => e.Masv == id);
        }
    }
}
