using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManagementAPI.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Category Description")]
        public string Description { get; set; }
    }
}