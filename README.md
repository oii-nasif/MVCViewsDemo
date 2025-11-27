# MVC Views Demo

An ASP.NET Core MVC demonstration project showcasing Razor Views, Tag Helpers, and various view-related features.

## Features

- **Razor Syntax** - Expressions, control structures, code blocks
- **Tag Helpers** - Built-in and custom tag helpers
- **View Data Passing** - ViewData, ViewBag, TempData
- **Partial Views** - Reusable view components
- **Form Validation** - Client and server-side validation
- **Localization** - Multi-language support (English, Bengali)
- **Layout Sections** - RenderBody, RenderSection

## Project Structure

```
MVCViewsDemo/
├── Controllers/
│   ├── HomeController.cs
│   ├── ProductsController.cs
│   ├── ContactController.cs
│   ├── DataDemoController.cs
│   └── TagHelpersController.cs
├── Models/
│   ├── Product.cs
│   ├── ContactFormModel.cs
│   └── ErrorViewModel.cs
├── TagHelpers/
│   ├── AlertTagHelper.cs
│   ├── BadgeTagHelper.cs
│   ├── EmailTagHelper.cs
│   ├── ProgressBarTagHelper.cs
│   └── TimeAgoTagHelper.cs
├── Views/
│   ├── Home/
│   ├── Products/
│   ├── Contact/
│   ├── DataDemo/
│   ├── TagHelpers/
│   └── Shared/
│       ├── _Layout.cshtml
│       ├── _Alert.cshtml
│       ├── _Pagination.cshtml
│       ├── _ProductCard.cshtml
│       └── _ValidationScriptsPartial.cshtml
├── Resources/
│   └── Views/DataDemo/
│       ├── Localization.en.resx
│       └── Localization.bn.resx
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
└── Program.cs
```

## Pages

| Page | Description |
|------|-------------|
| Home | Razor syntax demo with expressions, loops, conditionals |
| Products | Product catalog with partial views and sidebar |
| Contact | Form with validation using Form Tag Helpers |
| Data Demo | ViewData, ViewBag, TempData examples |
| Localization | Multi-language support demo |
| Tag Helpers | Built-in and custom Tag Helper examples |

## Custom Tag Helpers

| Tag Helper | Usage | Description |
|------------|-------|-------------|
| `<alert>` | `<alert type="success" dismissible="true">Message</alert>` | Bootstrap alert |
| `<badge>` | `<badge type="primary" pill="true">Text</badge>` | Bootstrap badge |
| `<email>` | `<email address="test@example.com" subject="Hello">` | Mailto link |
| `<progress-bar>` | `<progress-bar value="75" color="success">` | Progress bar |
| `<time-ago>` | `<time-ago date="@DateTime.Now.AddDays(-5)">` | Relative time |

## Technologies

- ASP.NET Core 8.0
- Bootstrap 5
- jQuery
- jQuery Validation

## Getting Started

### Prerequisites

- .NET 8.0 SDK

### Run the Application

```bash
cd MVCViewsDemo
dotnet run
```

Open browser at `https://localhost:7039` or `http://localhost:5154`

## Key Concepts Demonstrated

### Razor Syntax
- Implicit expressions: `@DateTime.Now`
- Explicit expressions: `@(5 + 3)`
- Code blocks: `@{ var x = 1; }`
- Control structures: `@if`, `@for`, `@foreach`, `@switch`

### Layout Sections
```cshtml
@section Sidebar {
    <!-- Sidebar content -->
}

@section Scripts {
    <!-- Additional scripts -->
}
```

### Tag Helpers
```cshtml
<a asp-controller="Home" asp-action="Index">Home</a>
<input asp-for="Name" />
<span asp-validation-for="Name"></span>
```

### View Data
```csharp
// Controller
ViewData["Message"] = "Hello";
ViewBag.User = new { Name = "John" };
TempData["Success"] = "Saved!";
```

### Localization
```cshtml
@inject IViewLocalizer Localizer
<h1>@Localizer["Welcome"]</h1>
```

## License

This project is for educational purposes.
