using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prematix.Web.Data;
using prematix.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace prematix.Web.Controllers
{
    public class PediatrasController : Controller
    {
        private readonly IRepository repository;

        public PediatrasController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Pediatras
        public IActionResult Index()
        {
            return View(this.repository.GetPediatras());
        }

        // GET: Pediatras/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pediatra = this.repository.GetPediatra(id.Value);
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Pediatra pediatra)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddPediatra(pediatra);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pediatra);
        }

        // GET: Pediatras/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pediatra = this.repository.GetPediatra(id.Value);
            if (pediatra == null)
            {
                return NotFound();
            }
            return View(pediatra);
        }

        // POST: Pediatras/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Pediatra pediatra)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdatePediatra(pediatra);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (this.repository.PediatraExists(pediatra.Id))
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pediatra = this.repository.GetPediatra(id.Value);
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
            var pediatra = this.repository.GetPediatra(id);
            this.repository.RemovePediatra(pediatra);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
