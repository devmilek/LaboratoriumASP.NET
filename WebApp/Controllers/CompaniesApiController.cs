using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesApiController : ControllerBase
{
    private readonly MoviesDbContext _context;

    public CompaniesApiController(MoviesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetFiltered(string filter)
    {
        return Ok(_context.ProductionCompanies
            .Where(o => o.CompanyName.ToLower().Contains(filter.ToLower()))
            .OrderBy(o => o.CompanyName)
            .AsNoTracking()
            .AsEnumerable()
        );
    }

}