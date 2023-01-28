using FieryrestaurantAPI.Model.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FieryrestaurantAPI.Model.DataAcciss
{
    public class SupplierDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FieryRestaurent;Integrated Security=True");
        }

        // table mapp
        public DbSet<Supplier> _supplier { get; set; }
    }
}