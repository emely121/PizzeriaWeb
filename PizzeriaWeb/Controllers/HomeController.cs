using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PizzeriaWeb.Models;

namespace PizzeriaWeb.Controllers;

public class HomeController : Controller
{
    // La página de inicio es el catálogo público.
    public IActionResult Index() => RedirectToAction("Index", "Catalogo");

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
