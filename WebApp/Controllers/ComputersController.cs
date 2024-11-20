using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Mappers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

public class ComputersController : Controller
{
    private readonly IComputerService _computerService;

    public ComputersController(IComputerService computerService)
    {
        _computerService = computerService;
    }

    // GET
    public IActionResult Index()
    {
        var computers = _computerService.FindAll();
        return View(computers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        Computer model = new Computer();
        model.Organizations = _computerService.FindAllOrganizations()
            .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title }).ToList();
        return View(model);
    }

    [HttpPost]
    public IActionResult Create(Computer model)
    {
        if (ModelState.IsValid)
        {
            _computerService.Add(model);
            return RedirectToAction("Index");
        }
        else
        {
            model.Organizations = _computerService.FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title }).ToList();
            return View(model); // ponowne wyświetlenie formularza z informacjami o błędach
        }
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var computer = _computerService.FindById(id);
        if (computer != null)
        {
            computer.Organizations = _computerService.FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title }).ToList();
            return View(computer);
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
            _computerService.Update(model);
            return RedirectToAction("Index");
        }
        else
        {
            model.Organizations = _computerService.FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title }).ToList();
            return View(model); // ponowne wyświetlenie formularza z informacjami o błędach
        }
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var computer = _computerService.FindById(id);
        if (computer != null)
        {
            return View(computer);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var computer = _computerService.FindById(id);
        if (computer != null)
        {
            _computerService.Delete(id);
            return RedirectToAction("Index");
        }
        else
        {
            return NotFound();
        }
    }
}