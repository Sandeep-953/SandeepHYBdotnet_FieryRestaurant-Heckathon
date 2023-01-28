using Microsoft.EntityFrameworkCore;
using ScholarHat.Models.Entities;

namespace ScholarHat.Models.DataAccess
{
    public class ShDbContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ScholarHatsandeep;Integrated Security=True");
        }
        public DbSet<Department> _Departments { get; set; }
        public DbSet<Employee> _Employees { get; set; }
    }
}
