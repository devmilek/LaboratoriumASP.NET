using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models.Heroes;
using Microsoft.AspNetCore.Authorization;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class HeroesController : Controller
    {
        private readonly HeroesDbContext _context;

        private readonly ILogger<HeroesController> _logger;

        public HeroesController(HeroesDbContext context, ILogger<HeroesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Powers(int page = 1, int size = 10)
        {
            var superpowers = _context.Superpowers
                .Select(sp => new HeroesViewsModels
                {
                    PowerName = sp.PowerName,
                    SuperheroCount = _context.HeroPowers.Count(hp => hp.PowerId == sp.Id)
                }).Skip((page -1) * size).Take(size)
                .AsAsyncEnumerable();
            
            return View(PagingListAsync<HeroesViewsModels>.Create(
                (p, s) =>
                    superpowers,
                _context.Superpowers.Count(),
                page,
                size));
        }

        // GET: Heroes
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            return View(PagingListAsync<Superhero>.Create(
                (p, s) =>
                    _context.Superheroes.Skip((p - 1) * s).OrderBy(b => b.SuperheroName).Take(s).AsAsyncEnumerable(),
                _context.Superheroes.Count(),
                page,
                size));
        }

        // GET: Heroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Superheroes
                .Include(s => s.Alignment)
                .Include(s => s.EyeColour)
                .Include(s => s.Gender)
                .Include(s => s.HairColour)
                .Include(s => s.Publisher)
                .Include(s => s.Race)
                .Include(s => s.SkinColour)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            var powers = await _context.HeroPowers
                .Where(hp => hp.HeroId == id)
                .Select(hp => hp.Power.PowerName)
                .ToListAsync();
            
            if (superhero == null)
            {
                return NotFound();
            }

            return View(new SuperheroDetailsViewModel
            {
                Superhero = superhero,
                Powers = powers
            });
        }

        // GET: Heroes/Create
        public IActionResult Create()
        {
            ViewData["AlignmentId"] = new SelectList(_context.Alignments, "Id", "Alignment1");
            ViewData["EyeColourId"] = new SelectList(_context.Colours, "Id", "Colour1");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Gender1");
            ViewData["HairColourId"] = new SelectList(_context.Colours, "Id", "Colour1");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "PublisherName");
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Race1");
            ViewData["SkinColourId"] = new SelectList(_context.Colours, "Id", "Colour1");
            return View();
        }

        // POST: Heroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuperheroName,Powers,FullName,GenderId,EyeColourId,HairColourId,SkinColourId,RaceId,PublisherId,AlignmentId,HeightCm,WeightKg")] SuperheroModel superhero)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Superheroes.Add(new Superhero()
                {
                    Id = _context.Superheroes.Max(s => s.Id) + 1,
                    SuperheroName = superhero.SuperheroName,
                    FullName = superhero.FullName,
                    GenderId = superhero.GenderId,
                    EyeColourId = superhero.EyeColourId,
                    HairColourId = superhero.HairColourId,
                    SkinColourId = superhero.SkinColourId,
                    RaceId = superhero.RaceId,
                    PublisherId = superhero.PublisherId,
                    AlignmentId = superhero.AlignmentId,
                    HeightCm = superhero.HeightCm,
                    WeightKg = superhero.WeightKg
                });

                foreach (var power in superhero.Powers)
                {
                    _context.HeroPowers.Add(new HeroPower()
                    {
                        HeroId = entity.Entity.Id,
                        PowerId = power
                    });
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["AvailablePowers"] = new SelectList(await _context.Superpowers.ToListAsync(), "Id", "PowerName");
            ViewData["AlignmentId"] = new SelectList(_context.Alignments, "Id", "Alignment1", superhero.AlignmentId);
            ViewData["EyeColourId"] = new SelectList(_context.Colours, "Id", "Colour1", superhero.EyeColourId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Gender1", superhero.GenderId);
            ViewData["HairColourId"] = new SelectList(_context.Colours, "Id", "Colour1", superhero.HairColourId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "PublisherName", superhero.PublisherId);
            ViewData["RaceId"] = new SelectList(_context.Races, "Id", "Race1", superhero.RaceId);
            ViewData["SkinColourId"] = new SelectList(_context.Colours, "Id", "Colour1", superhero.SkinColourId);

            return View(superhero);
        }

        private bool SuperheroExists(int id)
        {
            return _context.Superheroes.Any(e => e.Id == id);
        }
    }
}
