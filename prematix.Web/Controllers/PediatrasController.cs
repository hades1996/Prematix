using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prematix.Web.Data;
using prematix.Web.Data.Entities;

namespace prematix.Web.Controllers
{
    public class PediatrasController : Controller
    {
        private readonly DataContext _context;

        public PediatrasController(DataContext context)
        {
            _context = context;
        }

        // GET: Pediatras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pediatras.ToListAsync());
        }

        // GET: Pediatras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pediatra = await _context.Pediatras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pediatra == null)
            {
                return NotFound();
            }

            return View(pediatra);
        }

        // GET: Pediatras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pediatras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cedula,Entidad,Telefono,ImageUrl")] Pediatra pediatra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pediatra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pediatra);
        }

        // GET: Pediatras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pediatra = await _context.Pediatras.FindAsync(id);
            if (pediatra == null)
            {
                return NotFound();
            }
            return View(pediatra);
        }

        // POST: Pediatras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cedula,Entidad,Telefono,ImageUrl")] Pediatra pediatra)
        {
            if (id != pediatra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pediatra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PediatraExists(pediatra.Id))
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
            return View(pediatra);
        }

        // GET: Pediatras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pediatra = await _context.Pediatras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pediatra == null)
            {
                return NotFound();
            }

            return View(pediatra);
        }

        // POST: Pediatras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pediatra = await _context.Pediatras.FindAsync(id);
            _context.Pediatras.Remove(pediatra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PediatraExists(int id)
        {
            return _context.Pediatras.Any(e => e.Id == id);
        }
    }
}
