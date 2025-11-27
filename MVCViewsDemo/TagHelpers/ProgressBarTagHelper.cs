using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCViewsDemo.TagHelpers;

[HtmlTargetElement("progress-bar")]
public class ProgressBarTagHelper : TagHelper
{
    public int Value { get; set; } = 0;
    public string Color { get; set; } = "primary";
    public bool ShowLabel { get; set; } = false;
    public bool Striped { get; set; } = false;
    public bool Animated { get; set; } = false;
    public string Height { get; set; } = "1rem";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "progress");
        output.Attributes.SetAttribute("role", "progressbar");
        output.Attributes.SetAttribute("aria-valuenow", Value.ToString());
        output.Attributes.SetAttribute("aria-valuemin", "0");
        output.Attributes.SetAttribute("aria-valuemax", "100");
        output.Attributes.SetAttribute("style", $"height: {Height}");

        var barClass = $"progress-bar bg-{Color}";
        if (Striped)
        {
            barClass += " progress-bar-striped";
        }
        if (Animated)
        {
            barClass += " progress-bar-animated";
        }

        var label = ShowLabel ? $"{Value}%" : "";

        output.Content.SetHtmlContent(
            $"<div class=\"{barClass}\" style=\"width: {Value}%\">{label}</div>"
        );
    }
}
