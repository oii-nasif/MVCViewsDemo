using Microsoft.AspNetCore.Mvc;

namespace MVCViewsDemo.Controllers;

public class DataDemoController : Controller
{
    public IActionResult Index()
    {
        // ViewData demo
        ViewData["Title"] = "Data Demo";
        ViewData["Message"] = "This message is passed using ViewData";
        ViewData["CurrentTime"] = DateTime.Now;
        ViewData["Numbers"] = new List<int> { 1, 2, 3, 4, 5 };

        // ViewBag demo
        ViewBag.WelcomeMessage = "Welcome to the ViewBag demo!";
        ViewBag.User = new { Name = "John Doe", Email = "john@example.com" };
        ViewBag.Colors = new[] { "Red", "Green", "Blue", "Yellow" };

        return View();
    }

    public IActionResult FirstPage()
    {
        TempData["Message"] = "This message was set on FirstPage and will be available on SecondPage";
        TempData["Timestamp"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        return RedirectToAction("SecondPage");
    }

    public IActionResult SecondPage()
    {
        // TempData values set in FirstPage will be available here
        return View();
    }

    public IActionResult Localization()
    {
        return View();
    }
}
