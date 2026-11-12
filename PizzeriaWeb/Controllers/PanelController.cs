using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PizzeriaWeb.Controllers;

[Authorize]
public class PanelController : Controller
{
    public IActionResult Index() => View();
}
