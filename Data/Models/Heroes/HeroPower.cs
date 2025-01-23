using System;
using System.Collections.Generic;

namespace Data.Models.Heroes;

public partial class HeroPower
{
    public int? HeroId { get; set; }

    public int? PowerId { get; set; }

    public virtual Superhero? Hero { get; set; }

    public virtual Superpower? Power { get; set; }
}
