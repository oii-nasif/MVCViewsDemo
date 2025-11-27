using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCViewsDemo.TagHelpers;

[HtmlTargetElement("time-ago")]
public class TimeAgoTagHelper : TagHelper
{
    public DateTime Date { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.Attributes.SetAttribute("title", Date.ToString("F"));

        var timeAgo = GetTimeAgo(Date);
        output.Content.SetContent(timeAgo);
    }

    private static string GetTimeAgo(DateTime dateTime)
    {
        var timeSpan = DateTime.Now - dateTime;

        if (timeSpan.TotalSeconds < 60)
        {
            return timeSpan.Seconds == 1 ? "1 second ago" : $"{timeSpan.Seconds} seconds ago";
        }
        if (timeSpan.TotalMinutes < 60)
        {
            var minutes = (int)timeSpan.TotalMinutes;
            return minutes == 1 ? "1 minute ago" : $"{minutes} minutes ago";
        }
        if (timeSpan.TotalHours < 24)
        {
            var hours = (int)timeSpan.TotalHours;
            return hours == 1 ? "1 hour ago" : $"{hours} hours ago";
        }
        if (timeSpan.TotalDays < 30)
        {
            var days = (int)timeSpan.TotalDays;
            return days == 1 ? "1 day ago" : $"{days} days ago";
        }
        if (timeSpan.TotalDays < 365)
        {
            var months = (int)(timeSpan.TotalDays / 30);
            return months == 1 ? "1 month ago" : $"{months} months ago";
        }

        var years = (int)(timeSpan.TotalDays / 365);
        return years == 1 ? "1 year ago" : $"{years} years ago";
    }
}
