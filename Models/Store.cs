using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementAPI.Models
{
    [Table("Store")]
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Store Type")]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Store Type")]
        public string StoreType { get; set; } // Sub Branch, Main Branch
        [Required]
        [StringLength(150)]
        [Display(Name = "Business Type")]
        public string BusinessType { get; set; } // Hardware, Medical Store etc
        [Required]
        [Display(Name = "Address ID")]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}