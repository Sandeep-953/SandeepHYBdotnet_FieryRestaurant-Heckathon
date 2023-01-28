using System.ComponentModel.DataAnnotations;

namespace FieryrestaurantAPI.Model.Entites
{
    public class Supplier
    {
        [Required]
        [Key]
        public string? SupplireId { get; set; }
        [Required]
        public string? SupplierName { get; set; }
        [Required]
        public string? BusinessName { get; set; }
        [Required]
        public int LicenceNo { get; set; }
        [Required]
        public DateTime LicenceDate { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }
        [Required]
        public string? LastModifiedBy { get; set; }
        [Required]
        public string? StreetAdderss { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? ZipCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
