using System.ComponentModel.DataAnnotations;

namespace StoreManagement.ViewModels
{
    public class RoleVM
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NormalizedName { get; set; }

    }
}