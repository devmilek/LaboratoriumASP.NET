using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
        if (!model.IsValid() || model == null)
        {
            return View("CalculatorError");
        }
        return View(model);
    }
    public IActionResult Form()
    {
        return View();
    }
}