using System.Web;
using System.Web.Optimization;

namespace APRST.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/common.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/angular.js",
                     "~/Scripts/angular-animate.js"));

            bundles.Add(new ScriptBundle("~/bundles/customJS").Include(
                     "~/Scripts/AngularScripts/Module.js",
                     "~/Scripts/AngularScripts/Service.js",
                     "~/Scripts/AngularScripts/Controller.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-ui").Include(
                     "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/main.css",
                      "~/Content/css/media.css",
                      "~/Content/css/fonts.css",
                      "~/Content/css/font-awesome.css"));
        }
    }
}
