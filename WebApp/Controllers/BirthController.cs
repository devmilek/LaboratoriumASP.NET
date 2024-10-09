using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Form()
    {
        return View();
    }
    
    public IActionResult Result(BirthCalculator model)
    {
        if (!model.isValid())
        {
            return View("CalculatorError");
        }
        
        return View(model);
    }
}