using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BIWebApp.Helpers
{

    public static class HtmlHelperExtensions
    {
        public static IHtmlContent BootstrapButton(this IHtmlHelper htmlHelper, string text, string buttonType = "primary", string onClickAction = "#")
        {
            var buttonHtml = $@"
                <a href='{onClickAction}' class='btn btn-{buttonType}'>
                    {text}
                </a>";
            return new HtmlString(buttonHtml);
        }
    }
}
