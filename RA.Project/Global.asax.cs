using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Framework.IoC;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Common;
using Common.DTO;
using Framework.Logger;

namespace Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //IoC注册
            var assemblyFiles = Directory.GetFiles(Server.MapPath("bin/"), "*.dll");
            var assembly = assemblyFiles.Select(a => a.Contains("Impl") ? Assembly.LoadFile(a) : null).ToList();
            assembly.RemoveAll(a => a == null);
            LocalServiceLocator.RegisterModules(assembly.ToArray());
            LocalServiceLocator.SetContainer();
        }

        protected void Application_BeginRequest()
        {
            if (Request.Url.AbsolutePath == "/")
            {
                return;
            }
            if (Request.Cookies["userObj"] == null && Request.HttpMethod == "GET")
            {
                Response.Redirect("/");
            }
        }
        /// <summary>
        /// AOP:对于未处理异常的处理
        /// </summary>
        protected void Application_Error()
        {
            var e = Server.GetLastError();
            var operatorID = 0;
            var userObj =
                Serializer.Deserialize<UserInfoDTO>(HttpUtility.UrlDecode(Request.Cookies["userObj"].Value));
            if (userObj == null)
            {
                operatorID = -999;
            }
            else
            {
                operatorID = userObj.userID;
            }

            LoggerService.GetInstance().LogErrorToDb(e, operatorID);
            throw e;
        }
    }
}
