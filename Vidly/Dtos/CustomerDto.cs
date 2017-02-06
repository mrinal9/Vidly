using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

    
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedTonewsLetter { get; set; }

        public MemberShipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}