using ScholarHat.Models.Entities;

namespace ScholarHat.Models.DataAccess
{
    public interface IDepartmentRepository
    {
        void Save(Department depToSave);
        void Edit(Department depToEdit);
        void RejectDepartment(List<int> id);
        List<Department> GetDepartmentForReview();
        List<Department> GetSepertmentForBrows();
        void ApproveDepartment(List<int> id);
        Department GetDepaortmentById(int id);
        List<Department> GetDepartment();
        List<Department> SearchDepartment(string searchText);
    }
}
