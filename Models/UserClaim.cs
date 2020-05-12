using System;
using System.ComponentModel.DataAnnotations;

namespace StoreManagement.Models
{
    public class UserClaim
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string ClaimType { get; set; }

        [Required]
        [StringLength(50)]
        public string ClaimValue { get; set; }
    }
}