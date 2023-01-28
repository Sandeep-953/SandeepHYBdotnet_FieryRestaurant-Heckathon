using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScholarHat.Models.DataAccess;
using ScholarHat.Models.Entities;

namespace ScholarHat.Controllers
{
    public class DepartmentController : Controller
    {

        private IDepartmentRepository _depRepo;
        public DepartmentController(IDepartmentRepository depRepo)
        {
                       _depRepo = depRepo;
        }
        // GET: DepartmentController1
        public IActionResult Index( string searchText = null)
        {
            List<Department> department = null;
            if(searchText != null && searchText.Length >= 0)
            {department= _depRepo.SearchDepartment(searchText);
             
            }
            else
            {
                department =_depRepo.GetDepartment();
            }
            return View(department);
        }

        // GET: DepartmentController1/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController1/Create
        [HttpPost]
        
        public ActionResult Save(Department department)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View("Create");
                }
                _depRepo.Save(department);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController1/Edit/5
        public IActionResult Edit(int id)
        {
            Department department = _depRepo.GetDepaortmentById(id);
            return View(department);
        }

        // POST: DepartmentController1/Edit/5
        [HttpPost]
       
        public IActionResult Update( Department department)
        {
            try
            {
                if(!ModelState.IsValid && department == null)
                {
                    return View("Edit");
                }
                _depRepo.Edit(department);
                TempData["Message"]= "Employee data updated successfully";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(List<int> id)
        {
            try
            {
                _depRepo.RejectDepartment(id);
                TempData["message"] ="Department Rejected";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult BrowseDepartment()
        {
            var department = _depRepo.GetSepertmentForBrows();
            return View(department);
        }
        
    }
}
