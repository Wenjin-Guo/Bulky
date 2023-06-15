using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //ApplicationDbContext db = new ApplicationDbContext();
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)   //need to pass the object from create.cshtml
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot exactly match the name");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("name", "Test is not a valid value");
            }
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);       //keep track of inputs needed to be add to the database
                _categoryRepo.Save();              //in database create the category obj
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
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);      //another 2 methods to find the id
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null)
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
                _categoryRepo.Update(obj);       //keep track of inputs needed to be add to the database
                _categoryRepo.Save();              //in database create the category obj
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
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
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
            Category obj = _categoryRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Delete(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
