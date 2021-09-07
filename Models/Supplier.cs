using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementAPI.Models
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Name Type")]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Supplier Type")]
        public string SupplierType { get; set; } // Sub Branch, Main Branch
        [Required]
        [StringLength(150)]
        [Display(Name = "Business Type")]
        public string BusinessType { get; set; } // Hardware, Medical Supplier etc

        // [ForeignKey("ProductId")]
        // public virtual Product Product { get; set; }
        public Address Address { get; set; }

        public Supplier()
        {
            Address = new Address();
        }
    }
}