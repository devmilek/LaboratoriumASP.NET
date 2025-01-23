using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class MovieModel
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Overview cannot be longer than 500 characters")]
        public string? Overview { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Budget must be a positive number")]
        public int? Budget { get; set; }
        
        [Url(ErrorMessage = "Homepage must be a valid URL")]
        public string? Homepage { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Popularity must be a positive number")]
        public double? Popularity { get; set; }
        
        [Range(0, long.MaxValue, ErrorMessage = "Revenue must be a positive number")]
        public long? Revenue { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Runtime must be a positive number")]
        public int? Runtime { get; set; }
        
        [StringLength(200, ErrorMessage = "Tagline cannot be longer than 200 characters")]
        public string? Tagline { get; set; }

        [Range(0, 10, ErrorMessage = "Vote Average must be between 0 and 10")]
        public double? VoteAverage { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Vote Count must be a positive number")]
        public int? VoteCount { get; set; }
        
        [Required(ErrorMessage = "Company ID is required")]
        public int CompanyId { get; set; }
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Release Date is required")]
        public DateOnly ReleaseDate { get; set; }
    }
}