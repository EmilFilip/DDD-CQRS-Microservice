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

        public bool Deleted { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
