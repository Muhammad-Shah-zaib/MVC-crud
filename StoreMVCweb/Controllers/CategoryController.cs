using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using StoreMVCweb.Data;
using StoreMVCweb.Models;
using System.Security.Cryptography;

namespace StoreMVCweb.Controllers
{
    public class CategoryController : Controller
    {
        // creating a db member for getting the database
        private readonly AppDbContext db;

        public CategoryController(AppDbContext db)
        {
            // getting the database via DI
            this.db = db;
        }
        public IActionResult Index()
        {
            // getting the categories table in the database as a list
            IEnumerable<Category> objLategoryList = db.Categories;
            return View(objLategoryList); // passing the categories list in the view
        }
        // GET 
        public IActionResult Create()
        {
            return View(); // returning the view for out Create category
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category catObject)
        {
            if (catObject.Name == catObject.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Displat Order and Name can not be same.");
            }
            if (ModelState.IsValid)
            {
                this.db.Categories.Add(catObject);
                this.db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catObjFromDb = this.db.Categories.Find(id);
            return View(catObjFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category catObj)
        {
            if ( catObj.Name == catObj.Id.ToString())
            {
                ModelState.AddModelError(string.Empty, "Displat Order and Name can not be same.");
            }
            
            if ( ModelState.IsValid)
            {
                this.db.Categories.Update(catObj);
                this.db.SaveChanges();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete (int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var catObjFromDb = this.db.Categories.Find(id);
            return View(catObjFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category catObj)
        {
            this.db.Remove(catObj);
            this.db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
