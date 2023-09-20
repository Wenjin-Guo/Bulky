using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        //ApplicationDbContext db = new ApplicationDbContext();
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            //use Projection in EF core to retrieve list of category name
            
            if(id==null || id == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitOfWork.Company.Get(u=>u.Id==id);
                return View(companyObj);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(Company obj)   //need to pass the object from create.cshtml
        {
            
            if (ModelState.IsValid)
            {
                if(obj.Id == 0)
                {
                    _unitOfWork.Company.Add(obj);       //keep track of inputs needed to be add to the database
                    _unitOfWork.Save();
                    TempData["success"] = "Company created successfully.";
                }
                else
                {
                    _unitOfWork.Company.Update(obj);       //keep track of inputs needed to be add to the database
                    _unitOfWork.Save();
                    TempData["success"] = "Company updated successfully.";
                }
                
                return RedirectToAction("Index");   //redirect page to Company Index.cshtml
            }
            else
            {
                return View(obj);
            }
        }

        [HttpPost]
        public IActionResult Edit(Company obj)   //need to pass the object from create.cshtml
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Company.Update(obj);       //keep track of inputs needed to be add to the database
                _unitOfWork.Save();              //in database create the Company obj
                TempData["success"] = "Company edited successfully.";
                return RedirectToAction("Index");   //redirect page to Company Index.cshtml
            }
            else
            {
                return View();
            }
        }
       /* public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Company? CompanyFromDb = _unitOfWork.Company.Get(u => u.Id == id);
            //Company? CompanyFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);      //another 2 methods to find the id
            //Company? CompanyFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (CompanyFromDb == null)
            {
                return NotFound();
            }
            return View(CompanyFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)   //need to pass the object from create.cshtml
        {
            Company obj = _unitOfWork.Company.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Company.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Company deleted successfully.";
            return RedirectToAction("Index");
        }*/
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Company> objCompanyList = _unitOfWork.Company.
                GetAll().ToList();
            return Json(new { data  = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id==id);
            if(CompanyToBeDeleted == null)
            {
                return Json(new {success= false, message = "Error while deleting"});
            }
            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();
            
            return Json(new { success=true, message="Delete Successful" });
        }
        #endregion
    }
}
