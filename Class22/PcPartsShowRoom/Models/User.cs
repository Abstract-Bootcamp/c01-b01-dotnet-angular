using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcPartsShowRoom.Models
{
    public class User
    {
        [Key]
        public int TestId { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(3)]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [NotMapped]
        public int Tests2 { get; set; }

        // //from db
        // List<decimal> prices = new { 1, 154 };
        // [NotMapped]
        // public decimal TotalPrice => prices.Sum();
    }
}
