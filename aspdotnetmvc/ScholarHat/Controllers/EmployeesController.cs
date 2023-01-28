using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScholarHat.Models.DataAccess;
using ScholarHat.Models.Entities;

namespace ScholarHat.Controllers
{
    public class EmployeesController : Controller
    {
        private IDepartmentRepository _depRepo;
        private  IemployeeRepsitory _empRepo;
        public EmployeesController(IDepartmentRepository depRepo,IemployeeRepsitory empRepo)
        {
            _depRepo = depRepo;
            _empRepo = empRepo;
        }

        // GET: Employees
        public IActionResult Index()
        {
           

            return View();
            
        }

        // GET: Employees/Details/5
       

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList("DepartmentID", "Name");
            return View();
        }

        
        
        [HttpPost]
        [Authorize]
        public  IActionResult SubmitEmployee()
        {
            
            
                var employees = _depRepo.GetDepartment();
                var selectListemp = from emp in employees
                                    select new SelectListItem { Text=emp.Name, Value=emp.DepartmentID.ToString()};
                ViewBag.DepartmentID = selectListemp;
            
         
            return View();
        }

        [HttpPost]
        public IActionResult SubmitEmloyee(Employee employeeToSubmit)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("SubmitEmployee");
            }
            employeeToSubmit.IsApproved = false;
            _empRepo.Save(employeeToSubmit);
            TempData["Message"]= $"Employee {employeeToSubmit.Name} Submited successfully for reviw.";
            return RedirectToAction("SubmitEmployee");
        }
        
            public IActionResult Edit(int id)
        {
            Employee employee = _empRepo.GetEmployee(id);
            return View(employee);
        }

        // POST: Employees/Update/5
        
        [HttpPost]
       
        public IActionResult Update(int id, [Bind("EmployeeID,Name,Address,DepartmentId,IsApproved")] Employee employee)
        {
           if(!ModelState.IsValid && employee ==null)
            {
                return View("Edit");
            }
           _empRepo.Edit(employee);
            TempData["message"] = "Employee data updated successfully";
            return RedirectToAction("Index");
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(List<int> id)
        {
            _empRepo.RejectEmployee(id);
            TempData["Message"] ="Employee Deleted";
            return RedirectToAction("ReviewEmployee");
            

            
        }

       public IActionResult BrowseEmployee()
        {
            var employee = _empRepo.GetEmployeeForBrows();
            return View(employee);
        }
        public IActionResult ReviewEmployee()
        {
            var employeeforReview = _empRepo.GetEmpoyeeForReview();
            return View(employeeforReview);
        }
        public IActionResult Approve(List<int> empID)
        {
            _empRepo.ApproveEmployee(empID);
            return RedirectToAction("ReviewEmployee");
        }
    }
}
