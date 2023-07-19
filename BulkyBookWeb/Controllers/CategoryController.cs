using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _context.Categories;
            return View(objList);
        }

        public IActionResult Create()
        {
            //Category cat = new();
            //return View(cat);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //  ModelState.AddModelError("CustomError", "The boject...");
            //  ModelState.AddModelError("name", "The boject...");
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.Categories.Find(id);
            if (obj == null)
            {
                return NotFound("Index");
            }

            _context.Categories.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        
           
    }
}
}
