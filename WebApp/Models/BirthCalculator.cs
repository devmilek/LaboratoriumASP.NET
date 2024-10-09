namespace WebApp.Models;

public class BirthCalculator
{
    public string name { get; set; }
    public DateTime birthDate { get; set; }

    public bool isValid()
    {
        return birthDate != null && name != null && birthDate < DateTime.Now;
    }
    
    public int CalculateYears()
    {
        return DateTime.Now.Year - birthDate.Year;
    }
}