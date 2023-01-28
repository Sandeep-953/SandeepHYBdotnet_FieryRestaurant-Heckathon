using FieryrestaurantAPI.Model.Entites;

namespace FieryrestaurantAPI.Model.Repository
{
    public interface ISupplerRepository
    {
        Supplier GetSupplierById(string id);
        List<Supplier> GetSuppliers();
        List<Supplier> GetAllSuppliersByname(string name);
        List<Supplier> GetAllSuppliersByBusinessname(string businessname);
        List<Supplier> GetAllSuppliersByCuntry(string country);
        List<Supplier> GetAllSuppliersByZipCode(string zipcode);
        List<Supplier> GetAllSuppliersIsActive(bool isactive);
        List<Supplier> GetAllSuppliersByModifiedDate(DateTime modifieddate);
     
        List<Supplier> GetAllSuppliersByCity(string city);
        List<Supplier> GetAllSuppliersByState(string state);

        // Post
        void AddSupplier(Supplier supplier);
        // put
        void UpdateSupplier(Supplier supplier);
        // delete
        void DeleteSupplier(string supllierId);




    }
}
