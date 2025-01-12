using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Models;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class About_UsController : Controller
    {
        private readonly PetShopContext _context;

        public About_UsController(PetShopContext context)
        {
            _context = context;
        }

        // GET: Admin/About_Us
        public async Task<IActionResult> Index()
        {
            return View(await _context.About_Us.ToListAsync());
        }

        // GET: Admin/About_Us/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about_Us = await _context.About_Us
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about_Us == null)
            {
                return NotFound();
            }

            return View(about_Us);
        }

        // GET: Admin/About_Us/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/About_Us/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Text")] About_Us about_Us)
        {
            if (ModelState.IsValid)
            {
                _context.Add(about_Us);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about_Us);
        }

        // GET: Admin/About_Us/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about_Us = await _context.About_Us.FindAsync(id);
            if (about_Us == null)
            {
                return NotFound();
            }
            return View(about_Us);
        }

        // POST: Admin/About_Us/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text")] About_Us about_Us)
        {
            if (id != about_Us.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(about_Us);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!About_UsExists(about_Us.Id))
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
            return View(about_Us);
        }

        // GET: Admin/About_Us/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var about_Us = await _context.About_Us
                .FirstOrDefaultAsync(m => m.Id == id);
            if (about_Us == null)
            {
                return NotFound();
            }

            return View(about_Us);
        }

        // POST: Admin/About_Us/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var about_Us = await _context.About_Us.FindAsync(id);
            if (about_Us != null)
            {
                _context.About_Us.Remove(about_Us);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool About_UsExists(int id)
        {
            return _context.About_Us.Any(e => e.Id == id);
        }
    }
}