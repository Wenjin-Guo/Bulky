using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        //ApplicationDbContext db = new ApplicationDbContext();
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)   //need to pass the object from create.cshtml
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot exactly match the name");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("name", "Test is not a valid value");
            }
            if (ModelState.IsValid) 
            {
                _db.Categories.Add(obj);       //keep track of inputs needed to be add to the database
                _db.SaveChanges();              //in database create the category obj
                TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");   //redirect page to category Index.cshtml
            }
            else
            {
                return View();
            }
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);      //another 2 methods to find the id
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)   //need to pass the object from create.cshtml
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);       //keep track of inputs needed to be add to the database
                _db.SaveChanges();              //in database create the category obj
                TempData["success"] = "Category edited successfully.";
                return RedirectToAction("Index");   //redirect page to category Index.cshtml
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);      //another 2 methods to find the id
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)   //need to pass the object from create.cshtml
        {
            Category obj = _db.Categories.Find(id);
            if(obj == null) 
            { 
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
