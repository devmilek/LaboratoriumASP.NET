using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ComputersController : Controller
{
    static Dictionary<int, Computer> _computers = new Dictionary<int, Computer>();
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
}