using System.ComponentModel.DataAnnotations;

namespace MVCViewsDemo.Models;

public class ContactFormModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
    [Display(Name = "Full Name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Subject is required")]
    public string Subject { get; set; } = string.Empty;

    [Required(ErrorMessage = "Message is required")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 2000 characters")]
    public string Message { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [Display(Name = "Phone Number")]
    public string? Phone { get; set; }
}
