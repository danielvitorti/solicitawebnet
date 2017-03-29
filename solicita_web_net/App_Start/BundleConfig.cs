using System.Web;
using System.Web.Optimization;

namespace solicita_web_net
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/vendor/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/vendor/bootstrap/js/bootstrap.min.js",
                      "~/Scripts/respond.js",
                      "~/vendor/metisMenu/metisMenu.min.js",
                      "~/dist/js/sb-admin-2.js"

                      ));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/sb-admin-2.min.css",
                      "~/Content/site.css",
                      "~/vendor/font-awesome/css/font-awesome.min.css",
                      "~/morrisjs/morris.css",
                      "~/vendor/metisMenu/metisMenu.css"

                      )
                      
                      );
        }
    }
}
