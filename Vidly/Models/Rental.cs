using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
 
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
       
    }
}