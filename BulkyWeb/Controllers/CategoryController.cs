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
            if(ModelState.IsValid) 
            {
                _db.Categories.Add(obj);       //keep track of inputs needed to be add to the database
                _db.SaveChanges();              //in database create the category obj
                return RedirectToAction("Index");   //redirect page to category Index.cshtml
            }
            else
            {
                return View();
            }
            
            
        }
    }
}
