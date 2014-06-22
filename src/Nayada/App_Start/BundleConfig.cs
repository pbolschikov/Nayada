using System.Web.Optimization;

namespace Nayada
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/themes/base/css").Include("~/Content/bootstrap.css", "~/Content/bootstrap-theme.css", "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-1.9.0.js"));
        }
    }
}