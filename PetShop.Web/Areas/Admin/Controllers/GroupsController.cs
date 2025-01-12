using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Models.Products;
using PetShop.Domain.ViewModels;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class GroupsController : Controller
    {
        private readonly PetShopContext _context;

        public GroupsController(PetShopContext context)
        {
            _context = context;
        }

        // GET: Admin/Groups
        public async Task<IActionResult> Index()
        {
            var group = _context.Group.Include(u => u.User).Select(g => new GroupViewModel()
            {
                ShowHomeSite = g.ShowHomeSite,
                CreateDate = g.CreateDate,
                Description = g.Description,
                Id = g.Id,
                IsDeleted = g.IsDeleted,
                ModifiedDate = g.ModifiedDate,
                NameOwner = g.User.Name,
                Title = g.Title,
                UserIdOwner = g.User.Id,
            }).ToList();

            return View(group.OrderBy(u => u.IsDeleted));
        }

        // GET: Admin/Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groups = await _context.Group
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groups == null)
            {
                return NotFound();
            }

            return View(groups);
        }

        // GET: Admin/Groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Id,IsDeleted")] Groups groups)
        {
            var UserOwner = Convert.ToInt32(User.Claims.FirstOrDefault(u => u.Type == "id")?.Value);
            groups.UserIdOwner = UserOwner;
            if (ModelState.IsValid)
            {
                groups.CreateDate = DateTime.Now;
                _context.Add(groups);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(groups);
        }

        // GET: Admin/Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groups = _context.Group.Include(g => g.User).Where(g => g.Id == id).FirstOrDefault();
            if (groups == null)
            {
                return NotFound();
            }
            return View(groups);
        }

        // POST: Admin/Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Groups groups)
        {
            if (id != groups.Id)
            {
                return NotFound();
            }
            groups.CreateDate = groups.CreateDate;
            if (ModelState.IsValid)
            {
                try
                {
                    groups.ModifiedDate = DateTime.Now;
                    _context.Update(groups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupsExists(groups.Id))
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
            return View(groups);
        }

        // GET: Admin/Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groups = await _context.Group
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groups == null)
            {
                return NotFound();
            }

            return View(groups);
        }

        // POST: Admin/Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groups = await _context.Group.FindAsync(id);
            if (groups != null)
            {
                groups.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupsExists(int id)
        {
            return _context.Group.Any(e => e.Id == id);
        }
    }
}