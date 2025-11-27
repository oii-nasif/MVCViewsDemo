using Microsoft.AspNetCore.Mvc;
using MVCViewsDemo.Models;

namespace MVCViewsDemo.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View(new ContactFormModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(ContactFormModel model)
    {
        if (ModelState.IsValid)
        {
            // In a real application, you would process the form here
            // (e.g., send email, save to database, etc.)
            TempData["SuccessMessage"] = "Thank you for your message! We will get back to you soon.";
            return RedirectToAction("Index");
        }

        return View(model);
    }
}
