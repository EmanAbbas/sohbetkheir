using System.Web;
using System.Web.Optimization;

namespace Gam3iaWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                             "~/js/lib/jquery-1.10.2.min.js",
                             "~/js/lib/jquery-ui.min.js",
                             "~/js/lib/bootstrap.min.js",
                              "~/js/lib/jquery.dataTables.min.js",
                        "~/js/lib/dataTables.bootstrap.min.js",

                        "~/js/lib/dataTables.colReorder.min.js",
                              "~/js/script.js"


                             ));
            bundles.Add(new ScriptBundle("~/bundles/easing").Include("~/js/lib/easing.js",
                                "~/js/lib/classie.js",
                                   "~/js/lib/move-top.js",
                                      "~/js/lib/uisearch.js",
                
                                      "~/js/lib/jquery.validate.min.js"));
           bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/lib/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/js/lib/jquery.dataTables.min.js",
                        "~/js/lib/dataTables.bootstrap.min.js",
                        "~/js/lib/bootstrap-select.js",
                        "~/js/lib/dataTables.colReorder.min.js",
                              "~/js/script.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/css/bootstrap.css",
                      "~/css/bootstrap.flipped.css",
                      "~/css/jquery.dataTables.min.css",
                      "~/css/jquery-ui.min.css",
                      "~/css/jquery.dataTables_themeroller.css",
                      "~/css/dataTables.bootstrap.min.css",
                      "~/css/colReorder.bootstrap.min.css",
                     
                      "~/css/style.css",
                       "~/css/bootstrap-select.min.css"));
        }
    }
}
