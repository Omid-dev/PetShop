using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Models.Blog.Group;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogGroupsController : Controller
    {
        private readonly PetShopContext _context;

        public BlogGroupsController(PetShopContext context)
        {
            _context = context;
        }

        // GET: Admin/BlogGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogGroup.ToListAsync());
        }

        // GET: Admin/BlogGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogGroup = await _context.BlogGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogGroup == null)
            {
                return NotFound();
            }

            return View(blogGroup);
        }

        // GET: Admin/BlogGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogGroup blogGroup)
        {
            if (ModelState.IsValid)
            {
                blogGroup.CreateDate = DateTime.Now;
                _context.Add(blogGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogGroup);
        }

        // GET: Admin/BlogGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogGroup = await _context.BlogGroup.FindAsync(id);
            if (blogGroup == null)
            {
                return NotFound();
            }
            return View(blogGroup);
        }

        // POST: Admin/BlogGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogGroup blogGroup)
        {
            if (id != blogGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    blogGroup.CreateDate = blogGroup.CreateDate;
                    blogGroup.ModifiedDate = DateTime.Now;
                    _context.Update(blogGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogGroupExists(blogGroup.Id))
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
            return View(blogGroup);
        }

        // GET: Admin/BlogGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogGroup = await _context.BlogGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogGroup == null)
            {
                return NotFound();
            }

            return View(blogGroup);
        }

        // POST: Admin/BlogGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogGroup = await _context.BlogGroup.FindAsync(id);
            if (blogGroup != null)
            {
                blogGroup.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogGroupExists(int id)
        {
            return _context.BlogGroup.Any(e => e.Id == id);
        }
    }
}