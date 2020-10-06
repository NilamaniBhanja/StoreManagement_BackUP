using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementAPI.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Address1 { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }

        [StringLength(200)]
        public string LandMark { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string State { get; set; }
        [Required]
        [StringLength(200)]
        public string Country { get; set; }
        [Required]
        [StringLength(15)]
        public string PinCode { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }

        [StringLength(20)]
        [Display(Name = "Land Line Number")]
        public string LandLine { get; set; }
        [Required]
        [Display(Name = "Supplier ID")]
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

    }
}