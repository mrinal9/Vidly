using System;
using System.ComponentModel.DataAnnotations;
using Vidly.ViewModels;

namespace Vidly.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        [ValidateAgeForMembershipType]
        public DateTime? Birthdate { get; set; }
        
        public bool IsSubscribedTonewsLetter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        public byte MembershipTypeId { get; set; }
    }
}