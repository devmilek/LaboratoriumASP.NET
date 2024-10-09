using Microsoft.AspNetCore.Mvc;
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
    // GET
    
    public IActionResult Index()
    {
        return View(_computers);
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
            int id = _computers.Keys.Count != 0 ? _computers.Keys.Max() : 0;
            model.Id = id + 1;
            _computers.Add(model.Id, model);

            return RedirectToAction("Index");
        } else {
            return View(); // ponowne wyświetlenie formularza z informacjami o błędach
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
    
        if (_computers.Keys.Contains(id))
        {
            return View(_computers[id]);
        }
        else
        {
            return NotFound();
        };
    }
    
    [HttpPost]
    public IActionResult Edit(Computer model)
    {
        if (ModelState.IsValid)
        {
            _computers[model.Id] = model;
            return RedirectToAction("Index");
        } else {
            return View(); // ponowne wyświetlenie formularza z informacjami o błędach
        }
    }
}