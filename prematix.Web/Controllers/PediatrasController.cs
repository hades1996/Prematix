using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prematix.Web.Data;
using prematix.Web.Data.Entities;
using prematix.Web.Helpers;
using System.Threading.Tasks;

namespace prematix.Web.Controllers
{
    public class PediatrasController : Controller
    {
        private readonly IPediatraRepository pediatrarepository;
        private readonly IUserHelper userHelper;

        public PediatrasController(IPediatraRepository Pediatrarepository,IUserHelper userHelper)
        {
            pediatrarepository = Pediatrarepository;
            this.userHelper = userHelper;
        }

        // GET: Pediatras
        public IActionResult Index()
        {
            return View(this.pediatrarepository.GetAll());
        }

        // GET: Pediatras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pediatra = await this.pediatrarepository.GetByIdAsync(id.Value);
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
        public async Task<IActionResult> Create(Pediatra pediatra)
        {
            if (ModelState.IsValid)
            {
                //TODO: cambiar el usuario a dinamico
                pediatra.User = await this.userHelper.GetUserByEmailAsync("cristiancastillo.1996@gmail.com");
                await this.pediatrarepository.CreateAsync(pediatra);
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

            var pediatra = await this.pediatrarepository.GetByIdAsync(id.Value);
            if (pediatra == null)
            {
                return NotFound();
            }
            return View(pediatra);
        }

        // POST: Pediatras/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pediatra pediatra)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: cambiar el usuario a dinamico
                    pediatra.User = await this.userHelper.GetUserByEmailAsync("cristiancastillo.1996@gmail.com");
                    await this.pediatrarepository.UpdateAsync(pediatra);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.pediatrarepository.ExistAsync(pediatra.Id))
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

            var pediatra = await this.pediatrarepository.GetByIdAsync(id.Value);
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
            var pediatra = await this.pediatrarepository.GetByIdAsync(id);
            await this.pediatrarepository.DeleteAsync(pediatra);
            return RedirectToAction(nameof(Index));
        }

    }
}
