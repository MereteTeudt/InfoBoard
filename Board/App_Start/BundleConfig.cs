using System.Web;
using System.Web.Optimization;

namespace Board
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/customjs").Include(
                "~/Scripts/Custom.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Custom.css"));


            bundles.Add(new StyleBundle("~/Content/weather").Include(
                      "~/Content/weatherIcons/weather-icons-wind.css",
                      "~/Content/weatherIcons/weather-icons-wind.mini.css",
                      "~/Content/weatherIcons/weather-icons.css",
                      "~/Content/weatherIcons/weather-icons.mini.css"));
        }
    }
}
