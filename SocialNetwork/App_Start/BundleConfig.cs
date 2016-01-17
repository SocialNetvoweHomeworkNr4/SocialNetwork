using System.Web;
using System.Web.Optimization;

namespace SocialNetwork
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/handlebars").Include(
                "~/Scripts/Plugins/Handlebars/handlebars-v4.0.5.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-file-upload/js").Include(
                "~/Scripts/Plugins/jQueryFileUpload/js/vendor/jquery.ui.widget.js",
                "~/Scripts/Plugins/jQueryFileUpload/js/jquery.iframe-transport.js",
                "~/Scripts/Plugins/jQueryFileUpload/js/jquery.fileupload.js",
                "~/Scripts/Image/images.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/site/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/friends").Include(
                "~/Scripts/Friend/friend.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/profile-styles").Include(
                "~/Content/bootstrap-editable.css",
                 "~/Content/datepicker.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/profile-scripts").Include(
                 "~/Scripts/plugins/bootstrap-editable/bootstrap-editable.js",
                 "~/Scripts/profile/profile.js",
                 "~/Scripts/plugins/datepicker/bootstrap-datepicker.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/jquery-file-upload/css").Include(
                "~/Content/Plugins/jQueryFileUpload/css/jquery.fileupload-ui.css",
                "~/Content/Plugins/jQueryFileUpload/css/jquery.fileupload.css"
            ));


        }
    }
}
