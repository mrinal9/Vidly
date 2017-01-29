using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieDetailsViewModel
    {
        public IEnumerable<Genere> Genere { get; set; }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in stock")]
        public byte? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenereId { get; set; }

        public MovieDetailsViewModel()
        {
            Id = 0;
        }

        public MovieDetailsViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenereId = movie.GenereId;
            NumberInStock = movie.NumberInStock;
        }
    }
}