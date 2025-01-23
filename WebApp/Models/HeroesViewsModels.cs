using Data.Models.Heroes;

namespace WebApp.Models;

public class HeroesViewsModels
{
    public string PowerName { get; set; }
    public int SuperheroCount { get; set; }
}

public class SuperheroDetailsViewModel
{
    public Superhero Superhero { get; set; }
    public IEnumerable<string> Powers { get; set; }
}