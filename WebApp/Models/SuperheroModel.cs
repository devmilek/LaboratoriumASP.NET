using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SuperheroModel
    {
        [Required(ErrorMessage = "Superhero name is required")]
        [StringLength(100, ErrorMessage = "Superhero name cannot be longer than 100 characters")]
        public string SuperheroName { get; set; }
        
        [Required(ErrorMessage = "At least one power is required")]
        public List<int> Powers { get; set; }
        
        [StringLength(100, ErrorMessage = "Full name cannot be longer than 100 characters")]
        public string? FullName { get; set; }

        public int? GenderId { get; set; }

        public int? EyeColourId { get; set; }

        public int? HairColourId { get; set; }

        public int? SkinColourId { get; set; }

        public int? RaceId { get; set; }

        public int? PublisherId { get; set; }

        public int? AlignmentId { get; set; }

        [Range(0, 300, ErrorMessage = "Height must be between 0 and 300 cm")]
        public int? HeightCm { get; set; }

        [Range(0, 500, ErrorMessage = "Weight must be between 0 and 500 kg")]
        public int? WeightKg { get; set; }
    }
}