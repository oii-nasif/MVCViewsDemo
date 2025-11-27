using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace MVCViewsDemo.TagHelpers;

[HtmlTargetElement("email")]
public class EmailTagHelper : TagHelper
{
    public string Address { get; set; } = string.Empty;
    public string? Subject { get; set; }
    public string? Body { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";

        var href = new StringBuilder($"mailto:{Address}");
        var queryParams = new List<string>();

        if (!string.IsNullOrEmpty(Subject))
        {
            queryParams.Add($"subject={Uri.EscapeDataString(Subject)}");
        }

        if (!string.IsNullOrEmpty(Body))
        {
            queryParams.Add($"body={Uri.EscapeDataString(Body)}");
        }

        if (queryParams.Count > 0)
        {
            href.Append("?");
            href.Append(string.Join("&", queryParams));
        }

        output.Attributes.SetAttribute("href", href.ToString());

        var content = await output.GetChildContentAsync();
        if (content.IsEmptyOrWhiteSpace)
        {
            output.Content.SetContent(Address);
        }
        else
        {
            output.Content.SetHtmlContent(content.GetContent());
        }
    }
}
