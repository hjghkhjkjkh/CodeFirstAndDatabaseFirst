using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CODE_FIRST.Data;
using CODE_FIRST.Models;

namespace CODE_FIRST.Controllers
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
            return View(await _context.SINHVIEN.ToListAsync());
        }

        // GET: Sinhviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sINHVIEN = await _context.SINHVIEN
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sINHVIEN == null)
            {
                return NotFound();
            }

            return View(sINHVIEN);
        }

        // GET: Sinhviens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sinhviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DoB,lopId,khoaId")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sINHVIEN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sINHVIEN);
        }

        // GET: Sinhviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sINHVIEN = await _context.SINHVIEN.FindAsync(id);
            if (sINHVIEN == null)
            {
                return NotFound();
            }
            return View(sINHVIEN);
        }

        // POST: Sinhviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DoB,lopId,khoaId")] SINHVIEN sINHVIEN)
        {
            if (id != sINHVIEN.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sINHVIEN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SINHVIENExists(sINHVIEN.Id))
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
            return View(sINHVIEN);
        }

        // GET: Sinhviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sINHVIEN = await _context.SINHVIEN
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sINHVIEN == null)
            {
                return NotFound();
            }

            return View(sINHVIEN);
        }

        // POST: Sinhviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sINHVIEN = await _context.SINHVIEN.FindAsync(id);
            if (sINHVIEN != null)
            {
                _context.SINHVIEN.Remove(sINHVIEN);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SINHVIENExists(int id)
        {
            return _context.SINHVIEN.Any(e => e.Id == id);
        }
    }
}
