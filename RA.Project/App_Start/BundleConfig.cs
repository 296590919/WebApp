using System.Web;
using System.Web.Optimization;

namespace Project
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //全局js
            bundles.Add(new ScriptBundle("~/Scripts/head.js").Include(
                "~/Scripts/jquery-2.0.0.min.js",
                "~/Scripts/jquery-ui.js",
                "~/Scripts/jquery-cookie-1.4.1.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/check.js"));
            //全局css
            bundles.Add(new StyleBundle("~/CSS/head.css").Include(
                "~/CSS/bootstrap-combined.min.css",
                "~/CSS/common.css"
                ));

            Cooperation.Web.BundleConfig.RegisterBundles(bundles);
            MyBlog.Web.BundleConfig.RegisterBundles(bundles);
        }

    }
}
