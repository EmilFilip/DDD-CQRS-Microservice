using System;
using System.ComponentModel.DataAnnotations;

namespace STC.Customer.Infrastructure.Entities
{
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; }

        [Required]
        public int Age { get; set; }

        public bool Updated { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
