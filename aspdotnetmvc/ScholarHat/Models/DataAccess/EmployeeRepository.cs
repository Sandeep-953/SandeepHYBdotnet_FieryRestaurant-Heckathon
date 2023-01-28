using Microsoft.EntityFrameworkCore;
using ScholarHat.Models.Entities;

namespace ScholarHat.Models.DataAccess
{
    public class EmployeeRepository : IemployeeRepsitory
    {
        private ShDbContext _db;
        public EmployeeRepository(ShDbContext db)
        {
            _db = new ShDbContext();
        }

        public void ApproveEmployee(List<int> id)
        {
            foreach (var item in id)
            {
                var empToApprove = _db._Departments.Find(item);
                empToApprove.IsApproved = true;

            }
            _db.SaveChanges();
        }



        public void Delete(List<int> id)
        {
            foreach (var item in id)
            {
                var empTodelete = _db._Employees.Find(id);
                _db._Employees.Remove(empTodelete);
            }
            _db.SaveChanges();
        }

        public void Edit(Employee employeeToEdit)
        {
            _db._Employees.Update(employeeToEdit);
            _db.SaveChanges();
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                return _db._Employees.Find(id);
            }
            catch (EmployeeNotFindException ex)
            {
                throw ex;
            }
            
        }

        public List<Employee> GetEmployeeForBrows()
        {
            return _db._Employees.Where(a => a.IsApproved).ToList();
        }

        public List<Employee> GetEmpoyeeForReview()
        {
            var empToReview = from emp in _db._Employees.Include("Department")
                              where emp.IsApproved == false
                              select emp;
            return empToReview.ToList();
        }

        public void Save(Employee employeeToSave)
        {
            _db._Employees.Add(employeeToSave);
        }

        public List<Employee> SearchEmployees(string searchText)
        {
            var emptosearch = from emp in _db._Employees
                              where emp.Name.Contains(searchText) ||
                              emp.Address.Contains(searchText)
                              select emp;
            return emptosearch.ToList();
        }

        public void RejectEmployee(List<int> id)
        {
            var empTodelete = _db._Employees.Find(id);
            _db._Employees.Remove(empTodelete);
            _db.SaveChanges(true);
        }
    }
}
