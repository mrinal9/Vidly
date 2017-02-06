using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public DateTime ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public GenereDto Genere { get; set; }

        [Required]
        public byte GenereId { get; set; }
    }
}