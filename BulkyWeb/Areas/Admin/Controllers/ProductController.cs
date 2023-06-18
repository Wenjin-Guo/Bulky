using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)   //need to pass the object from create.cshtml
        {
           
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);       //keep track of inputs needed to be add to the database
                _unitOfWork.Save();              //in database create the product obj
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");   //redirect page to product Index.cshtml
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
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //Product? productFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);      //another 2 methods to find the id
            //Product? productFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)   //need to pass the object from create.cshtml
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);       //keep track of inputs needed to be add to the database
                _unitOfWork.Save();              //in database create the product obj
                TempData["success"] = "Product edited successfully.";
                return RedirectToAction("Index");   //redirect page to product Index.cshtml
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
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            //Product? productFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);      //another 2 methods to find the id
            //Product? productFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)   //need to pass the object from create.cshtml
        {
            Product obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Delete(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
