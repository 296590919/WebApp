using Framework;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace Cooperation.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //登录页js
            bundles.Add(new ScriptBundle("~/Scripts/login-head.js").Include(
                "~/Scripts/jquery-2.0.0.min.js",
                "~/Scripts/jquery-ui.js",
                "~/Scripts/jquery-cookie-1.4.1.js",
                "~/Scripts/bootstrap.min.js"
                ));

            //登录提交js
            bundles.Add(new ScriptBundle("~/Scripts/login.js").Include(
                "~/Areas/Cooperation/Scripts/login.js"
                ));
        }
    }
}
