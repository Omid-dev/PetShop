using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Models.Products;
using PetShop.Infra.Data.Context;

namespace PetShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly PetShopContext _context;

        public ProductsController(PetShopContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var petShopContext = _context.Product.Include(p => p.Groups).Include(p => p.User).OrderBy(g => g.IsDeleted);
            return View(await petShopContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Groups)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Group.Where(g => g.IsDeleted.ToString().ToLower() == "false"), "Id", "Title");
            //ViewData["UserIdOwner"] = new SelectList(_context.User, "Id", "Email");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Price,Name,Stock,Desctiption,Text,GroupId,ImageName,Id,IsDeleted")] Product product, IFormFile imgUpload)
        {
            int useridLogin = Convert.ToInt32((User.Claims.SingleOrDefault(u => u.Type == "id")?.Value));
            product.UserIdOwner = useridLogin;
            product.CreateDate = DateTime.Now;

            product.Price = product.Price;

            if (imgUpload != null)
            {
                var imgstring = Guid.NewGuid().ToString() + Path.GetExtension(imgUpload.FileName);
                product.ImageName = imgstring;
                var imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImages", imgstring).ToString();
                var filestreem = new FileStream(imgpath, FileMode.Create);
                imgUpload.CopyTo(filestreem);
            }
            else
            {
                product.ImageName = "nophoto.jpg";
            }

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Group.Where(g => g.IsDeleted.ToString().ToLower() == "false"), "Id", "Title", product.GroupId);
            ViewData["UserIdOwner"] = new SelectList(_context.User, "Id", "Email", product.UserIdOwner);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Title", product.GroupId);
            ViewData["UserIdOwner"] = new SelectList(_context.User, "Id", "Email", product.UserIdOwner);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Price,Name,Stock,Desctiption,Text,GroupId,UserIdOwner,Id,CreateDate,ModifiedDate,IsDeleted,ImageName")] Product product, IFormFile? imgUpload)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            if (imgUpload != null)
            {
                string imgname = Guid.NewGuid().ToString() + Path.GetExtension(imgUpload.FileName);
                product.ImageName = imgname;
                string imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImages", imgname.ToString());
                if (imgpath.Any() && imgpath != null)
                {
                    var file = new FileStream(imgpath, FileMode.Create);
                    imgUpload.CopyTo(file);
                }
            }

            product.ModifiedDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["GroupId"] = new SelectList(_context.Group, "Id", "Title", product.GroupId);
            ViewData["UserIdOwner"] = new SelectList(_context.User, "Id", "Email", product.UserIdOwner);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Groups)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                product.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}