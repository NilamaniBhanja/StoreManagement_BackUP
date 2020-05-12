using System;
using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Models
{
    public class User
    {
        [Required]
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}