using Microsoft.AspNetCore.Mvc;

namespace MVCViewsDemo.Controllers;

public class TagHelpersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult BuiltIn()
    {
        return View();
    }

    public IActionResult Custom()
    {
        return View();
    }
}
