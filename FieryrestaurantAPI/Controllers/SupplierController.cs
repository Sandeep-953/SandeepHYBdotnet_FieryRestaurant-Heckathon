using FieryrestaurantAPI.Model.DataAcciss;
using FieryrestaurantAPI.Model.Entites;
using FieryrestaurantAPI.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.OData;

namespace FieryrestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplerRepository repo = new SupplierRepository();


        [HttpGet]
        [EnableQuery]
        public IActionResult GetAllSupplier() 
        {
            return Ok(repo.GetSuppliers().AsQueryable());   
        }
        [HttpPost]
        public IActionResult PostSuppplier(Supplier supplier)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(" invalid product data");
            }
            repo.AddSupplier(supplier);
            return Ok();
        }
        [HttpPut]
        public IActionResult PutSuppliers(Supplier supplier) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest( " Invalid product data");
            }
            repo.UpdateSupplier(supplier);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]

        public IActionResult DeleteSuppliers(string id)
        {
            Supplier s = repo.GetSupplierById(id);
            if(s== null)
            {
                return NotFound();
            }
            else
            {
                repo.DeleteSupplier(id);
                return Ok();
            }
           

        }




    }
}
