using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementAPI.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(200)]
        [Display(Name = "Product Description")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name = "Product Stock")]
        public int QtyInStock { get; set; }
        public ProductCost productCost { get; set; }
        // public Supplier supplier { get; set; }
        public Product()
        {
            productCost = new ProductCost();
            // supplier = new Supplier();
        }  
        
       
    }
}