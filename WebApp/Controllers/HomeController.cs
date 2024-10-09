using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Calculator(Operator op, double a, double b)
    {
        
        double result = op switch
        {
            Operator.Add => a + b,
            Operator.Sub => a - b,
            Operator.Mul => a * b,
            Operator.Div => b != 0 ? a / b : double.NaN,
            _ => double.NaN
        };
        
        ViewBag.Op = op;
        ViewBag.A = a;
        ViewBag.B = b;
        ViewBag.Result = result;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}