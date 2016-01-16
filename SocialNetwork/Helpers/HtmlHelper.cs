using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace SocialNetwork.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper, string text, string action, string controller, string spanGlyphicon = null)
        {
            var li = new TagBuilder("li");

            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");
            if (string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("active");
            }


            if (string.IsNullOrEmpty(spanGlyphicon) == false)
            {

                var anc = new TagBuilder("a");
                string link = "\\" + controller + "\\" + action;
                anc.MergeAttribute("href", link);

                anc.InnerHtml = spanGlyphicon + " " + text;

                li.InnerHtml = (anc.ToString());
            }
            else
            {
                li.InnerHtml = htmlHelper.ActionLink(text, action, controller).ToHtmlString();
            }

            return MvcHtmlString.Create(li.ToString());
        }
    }


}