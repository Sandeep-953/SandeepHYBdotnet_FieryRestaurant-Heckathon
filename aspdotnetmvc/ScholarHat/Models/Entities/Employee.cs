using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace ScholarHat.Models.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "{0} con't be empty or null")]
        [Display(Name= "Employee Name")]
        [StringLength(30,MinimumLength =5,ErrorMessage ="{0} shold be between {2} and {1} Charactors long")]
        [RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} should contain only alphabets, space and dot (.)")]     
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} con't be empty or null")]
        [Display(Name = "Employee Address")]
        [StringLength(60, MinimumLength = 15, ErrorMessage = "{0} shold be between {2} and {1} Charactors long")]
        public string Address { get; set; }
        public int DepartmentId { get; set; }

        public Department Departments { get; set; }
        public bool IsApproved { get; set; }
        public override string ToString()
        {
            return $"Employee object- Employee name:{Name}, Address: {Address} ,and Department Id :{DepartmentId} and Departments ;{Departments}";
        }
    }
}
