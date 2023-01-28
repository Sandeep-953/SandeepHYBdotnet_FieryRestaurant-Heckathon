using FieryrestaurantAPI.Model.Entites;
using FieryrestaurantAPI.Model.Repository;

namespace FieryrestaurantAPI.Model.DataAcciss
{
    public class SupplierRepository : ISupplerRepository

    {
        private SupplierDbContext db = new SupplierDbContext();
        public void AddSupplier(Supplier supplier)
        {
            db._supplier.Add(supplier);
            db.SaveChanges();
        }

        public void DeleteSupplier(string supllierId)
        {
            var supplierToDel = db._supplier.Find(supllierId);
            db._supplier.Remove(supplierToDel);
            db.SaveChanges();
        }

        public List<Supplier> GetAllSuppliers()
        {
            return db._supplier.ToList();
        }

        public List<Supplier> GetAllSuppliersByBusinessname(string businessname)
        {

            return (from s in db._supplier
                    where s.BusinessName==businessname
                    select s).ToList();
        }

        public List<Supplier> GetAllSuppliersByCity(string city)
        {
            return (from s in db._supplier
                    where s.City==city
                    select s).ToList();
        }


        public List<Supplier> GetAllSuppliersByCuntry(string country)
        {
            return (from s in db._supplier
                    where s.Country==country
                    select s).ToList();
        }

        public List<Supplier> GetAllSuppliersByModifiedDate(DateTime modifieddate)
        {
            return (from s in db._supplier
                    where s.LastModifiedDate == modifieddate
                    select s).ToList();
        }

        

        public List<Supplier> GetAllSuppliersByname(string name)
        {
            return (from s in db._supplier
                    where s.SupplierName == name
                    select s).ToList();
        }

        public List<Supplier> GetAllSuppliersByState(string state)
        {
            return (from s in db._supplier
                    where s.State== state
                    select s).ToList();
        }

        public List<Supplier> GetAllSuppliersByZipCode(string zipcode)
        {
            return (from s in db._supplier
                    where s.ZipCode == zipcode
                    select s).ToList();
        }

        public List<Supplier> GetAllSuppliersIsActive(bool isactive)
        {
            return (from s in db._supplier
                    where s.IsActive == isactive
                    select s).ToList();
        }



        public Supplier GetSupplierById(string id)
        {
            return db._supplier.Find(id);
        }



        public List<Supplier> GetSuppliers()
        {
            return db._supplier.ToList();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            db._supplier.Update(supplier);
            db.SaveChanges();
        }
    }
}
