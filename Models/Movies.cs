using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoRental.Models
{
    public class Movies
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("Genre")]
        [Display(Name = "Genre")]  
        [Required]
        public byte GenreId { get; set; }

        [Display(Name = "Release Date")]  
        [Required]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]  
        [Range(1,20)]
        [Required]
        public int NumberInStock { get; set; }
        public Genres Genre { get; set; }

        public int NumberAvailable { get; set; }
    }
}