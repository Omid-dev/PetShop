using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Application.Utility;
using PetShop.Domain.Models.Blog.Group;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly PetShopContext _context;

        public BlogsController(PetShopContext context)
        {
            _context = context;
        }

        // GET: Admin/Blogs
        public async Task<IActionResult> Index()
        {
            var petShopContext = _context.Blog.Include(b => b.BlogGroup).Include(b => b.User);
            return View(await petShopContext.ToListAsync());
        }

        // GET: Admin/Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .Include(b => b.BlogGroup)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.BlogGroup, "Id", "Title");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog, IFormFile ImgUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImgUpload == null)
                {
                    blog.ImageName = "nophoto";
                }

                var imgName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUpload.FileName).ToString();
                var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImage", imgName).ToString();
                using (var file = new FileStream(imgPath, FileMode.Create))
                {
                    ImgUpload.CopyTo(file);
                }
                blog.ImageName = imgName;

                blog.CreateDate = DateTime.Now;
                blog.UserId = User.GetUserId();
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.BlogGroup, "Id", "Title", blog.GroupId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", blog.UserId);
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.BlogGroup, "Id", "Title", blog.GroupId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Name", blog.UserId);
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Blog blog, IFormFile ImgUpload)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    blog.CreateDate = blog.CreateDate;
                    blog.ModifiedDate = DateTime.Now;
                    if (ImgUpload == null)
                    {
                        blog.ImageName = blog.ImageName;
                    }
                    else
                    {
                        var imgName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUpload.FileName).ToString();
                        var imgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImage", imgName).ToString();

                        var imgnameold = _context.Blog.AsNoTracking().SingleOrDefault(b => b.Id == id).ImageName;
                        var imgpathold = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImage", imgnameold).ToString();

                        if (System.IO.File.Exists(imgpathold))
                        {
                            System.IO.File.Delete(imgpathold);
                        }
                        using (var file = new FileStream(imgPath, FileMode.Create))
                        {
                            ImgUpload.CopyTo(file);
                        }
                        blog.ImageName = imgName;
                    }
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id))
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
            ViewData["GroupId"] = new SelectList(_context.BlogGroup, "Id", "Description", blog.GroupId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", blog.UserId);
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .Include(b => b.BlogGroup)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blog.FindAsync(id);
            if (blog != null)
            {
                blog.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.Id == id);
        }
    }
}