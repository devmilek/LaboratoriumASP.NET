using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

[Route("api/powers")]
[ApiController]
public class HeroesApiController : ControllerBase
{
    private readonly HeroesDbContext _context;

    public HeroesApiController(HeroesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetFiltered(string filter)
    {
        return Ok(_context.Superpowers
            .Where(o => o.PowerName.ToLower().Contains(filter.ToLower()))
            .OrderBy(o => o.PowerName).Take(20)
            .AsNoTracking()
            .AsEnumerable()
        );
    }

}