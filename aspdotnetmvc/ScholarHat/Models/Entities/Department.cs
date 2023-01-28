using System.ComponentModel.DataAnnotations;

namespace ScholarHat.Models.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "{0} con't be empty or null")]
        [Display(Name = "Department Name")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "{0} shold be between {2} and {1} Charactors long")]
        [RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} should contain only alphabets, space and dot (.)")]
        public string Name { get; set; }
        public bool IsApproved { get; set; }
    }
}
