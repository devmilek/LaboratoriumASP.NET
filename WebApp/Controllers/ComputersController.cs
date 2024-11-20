using Data;
using Microsoft.AspNetCore.Mvc;
using WebApp.Mappers;
using WebApp.Models;

namespace WebApp.Controllers;

public class ComputersController : Controller
{
    static Dictionary<int, Computer> _computers = new Dictionary<int, Computer>
    {
        {1, new Computer { Id = 1, Name = "Komputer 1", Processor = "Intel i5", Memory = "8GB", GraphicsCard = "Nvidia GTX 1050", Manufacturer = "Dell", ProductionDate = new DateTime(2020, 1, 1) }},
        {2, new Computer { Id = 2, Name = "Komputer 2", Processor = "Intel i7", Memory = "16GB", GraphicsCard = "Nvidia GTX 1060", Manufacturer = "HP", ProductionDate = new DateTime(2021, 1, 1) }},
        {3, new Computer { Id = 3, Name = "Komputer 3", Processor = "AMD Ryzen 5", Memory = "32GB", GraphicsCard = "AMD Radeon RX 5700", Manufacturer = "Lenovo", ProductionDate = new DateTime(2022, 1, 1) }}
    };
    
    private readonly AppDbContext _context;

    public ComputersController(AppDbContext context)
    {
        _context = context;
    }
    // GET
    
    public IActionResult Index()
    {
        var computers = _context.Computers.ToList();
        return View(computers);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Computer model)
    {
        if (ModelState.IsValid)
        {
            var entity = ComputerMapper.ToEntity(model);
            _context.Computers.Add(entity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View(); // ponowne wyświetlenie formularza z informacjami o błędach
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var computer = _context.Computers.Find(id);
        if (computer != null)
        {
            return View(ComputerMapper.FromEntity(computer));
        }
        else
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    public IActionResult Edit(Computer model)
    {
        if (ModelState.IsValid)
        {
            var entity = ComputerMapper.ToEntity(model);
            _context.Computers.Update(entity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return View(); // ponowne wyświetlenie formularza z informacjami o błędach
        }
    }
    
    [HttpGet]
    public IActionResult Details(int id)
    {
        var computer = _context.Computers.Find(id);
        if (computer != null)
        {
            return View(ComputerMapper.FromEntity(computer));
        }
        else
        {
            return NotFound();
        };
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var computer = _context.Computers.Find(id);
        if (computer != null)
        {
            _context.Computers.Remove(computer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
}