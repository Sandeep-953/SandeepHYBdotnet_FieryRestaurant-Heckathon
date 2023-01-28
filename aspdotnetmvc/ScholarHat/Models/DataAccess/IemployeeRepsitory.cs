using ScholarHat.Models.Entities;

namespace ScholarHat.Models.DataAccess
{
    public interface IemployeeRepsitory
    {
        void Save(Employee employeeToSave);
        void Edit(Employee employeeToEdit);
        void RejectEmployee(List<int> id);
        List<Employee> GetEmpoyeeForReview();
        List<Employee> GetEmployeeForBrows();
        void ApproveEmployee(List<int> id);
        Employee GetEmployee(int id);
        List<Employee> SearchEmployees(string searchText);
    }
}
