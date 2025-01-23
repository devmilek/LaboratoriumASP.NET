using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class MovieModel
{
    public string? Title { get; set; }

    public string? Overview { get; set; }
    
    public int? Budget { get; set; }
    
    public string? Homepage { get; set; }

    public double? Popularity { get; set; }
    
    public long? Revenue { get; set; }

    public int? Runtime { get; set; }
    
    public string? Tagline { get; set; }

    public double? VoteAverage { get; set; }

    public int? VoteCount { get; set; }
    
    public int CompanyId { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly ReleaseDate { get; set; }
}