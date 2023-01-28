using Microsoft.EntityFrameworkCore;
using ScholarHat.Models.Entities;

namespace ScholarHat.Models.DataAccess
{
    public class DepartmentRepository : IDepartmentRepository

    {
        private readonly ShDbContext _db;
        public DepartmentRepository(ShDbContext context)
        {
            _db= new ShDbContext();
        }
        public void ApproveDepartment(List<int> id)
        {
            try
            {


                foreach (var aid in id)
                {
                    var depToApprove = _db._Departments.Find(aid);
                    depToApprove.IsApproved = true;

                }
            }catch(EmployeeNullebilException ex)
            {
                throw ex;

            }
            _db.SaveChanges();
        }

        public void RejectDepartment(List<int> id)
        {
            try
            {


                foreach (var item in id)
                {
                    var depToReject = _db._Departments.Find(item);
                    _db._Departments.Remove(depToReject);
                }
            }
            catch(EmployeeNullebilException ex) { throw ex; }
            _db.SaveChanges();
        }

        public void Edit(Department depToEdit)
        {
            _db._Departments.Update(depToEdit);
            _db.SaveChanges();
        }

        public Department GetDepaortmentById(int id)
        {
            try
            {
                return _db._Departments.Find(id);

            }
            catch (EmployeeNotFindException ex)
            {
                throw ex;
            }
            
        }

        public List<Department> GetDepartment()
        {
            return _db._Departments.ToList();
        }

        public List<Department> GetDepartmentForReview()
        {
            var articles = from a in _db._Departments.Include("Employee")
                           where a.IsApproved == false
                           select a;
            return articles.ToList();
        }

        public List<Department> GetSepertmentForBrows()
        {
            return _db._Departments.Where(a => a.IsApproved).ToList();
        }



        public void Save(Department depToSave)
        {
            _db._Departments.Add(depToSave);
            _db.SaveChanges(true);
        }

        public List<Department> SearchDepartment(string searchText)
        {
            var deportment = from c in _db._Departments
                             where c.Name.Contains(searchText)

                             select c;
            return deportment.ToList();
        }
    }
}
