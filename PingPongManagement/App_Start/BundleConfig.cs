using System.Web;
using System.Web.Optimization;

namespace PingPongManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Script/AngularApp")
                .Include(
                "~/AngularApp/dist/AngularApp/runtime.*",
                "~/AngularApp/dist/AngularApp/polyfills.*",
                "~/AngularApp/dist/AngularApp/styles.*",
                "~/AngularApp/dist/AngularApp/vendor.*",
                "~/AngularApp/dist/AngularApp/main.*"));
        }
    }
}
