using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class Computer
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Proszę podać imię!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Proszę uzupełnić procesor!")]
    public string Processor { get; set; }

    [Required(ErrorMessage = "Proszę uzupełnić pamięć!")]
    public string Memory { get; set; }

    [Required(ErrorMessage = "Proszę uzupełnić kartę graficzną!")]
    public string GraphicsCard { get; set; }

    [Required(ErrorMessage = "Proszę uzupełnić producenta!")]
    public string Manufacturer { get; set; }

    [Required(ErrorMessage = "Proszę uzupełnić datę produkcji!")]
    [DataType(DataType.Date, ErrorMessage = "Proszę podać poprawną datę!")]
    public DateTime ProductionDate { get; set; }
}