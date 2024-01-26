using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieProject.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a year")]
        [Range(1900, 2024, ErrorMessage = "Year must be between 1900 and 2024")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a rating")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int? Rating { get; set; }

        //Readonly property for the slug
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString();

        //Foreign Key Property
        //Your entity classes are easier to work with if you add FK properties that refere to the PK in the related entity class.
        [Required(ErrorMessage = "Please enter a genre")]
        public string GenreId { get; set; } = string.Empty;

        //Navigation Property
        [ValidateNever]
        public Genre Genre { get; set; } = null!;

    }
}
