using System.Web.Optimization;

namespace APRST.WEB
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/common.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                     "~/Scripts/angular.js",
                     "~/Scripts/angular-sanitize.js",
                     "~/Scripts/angular-resource.js",
                     "~/Scripts/angular-route.js",
                     "~/Scripts/angular-animate.js"));

            bundles.Add(new ScriptBundle("~/bundles/customJS").Include(
                     "~/Scripts/AngularScripts/Module.js",
                     "~/Scripts/AngularScripts/Service.js",
                     "~/Scripts/AngularScripts/Controller.js",
                     "~/Scripts/AngularScripts/ModalsControllers.js"));

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