using System.Web.Optimization;

namespace NGnono.FMNote.WebSite4Api.Core.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //bundles.IgnoreList.Ignore("*.intellisense.js");
            //bundles.IgnoreList.Ignore("*-vsdoc.js");
            //bundles.IgnoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            //bundles.IgnoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);

            bundles.Add(new ScriptBundle("~/bundles/basejs").Include(
                "~/sencha-touch-all.js"));

            bundles.Add(new ScriptBundle("~/bundles/appjs").Include(
                "~/app.js"));

            bundles.Add(new StyleBundle("~/Content/basecss").Include("~/resources/css/sencha-touch.css"));
        }
    }
}