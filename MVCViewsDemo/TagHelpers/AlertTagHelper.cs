using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCViewsDemo.TagHelpers;

[HtmlTargetElement("alert")]
public class AlertTagHelper : TagHelper
{
    public string Type { get; set; } = "info";
    public bool Dismissible { get; set; } = false;
    public string? Icon { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("role", "alert");

        var cssClass = $"alert alert-{Type}";
        if (Dismissible)
        {
            cssClass += " alert-dismissible fade show";
        }
        output.Attributes.SetAttribute("class", cssClass);

        var content = await output.GetChildContentAsync();
        var innerHtml = "";

        if (!string.IsNullOrEmpty(Icon))
        {
            innerHtml += $"<i class=\"{Icon} me-2\"></i>";
        }

        innerHtml += content.GetContent();

        if (Dismissible)
        {
            innerHtml += "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>";
        }

        output.Content.SetHtmlContent(innerHtml);
    }
}
