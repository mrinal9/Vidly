using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.AccessControl;

namespace Vidly.Models
{
    public class Movie
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        
        public DateTime? DateAdded { get; set; }
        
        [Display(Name="Number in stock")]
        public byte NumberInStock { get; set; }
      
        public Genere Genere { get; set; }
        
        [Required]
        [Display(Name = "Genre")]
        public byte GenereId { get; set; }
       
    }
}