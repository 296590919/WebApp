using System.Web.Mvc;
using Cooperation.Service.Interface.api;
using Cooperation.Service.Interface.Login;
using Framework.IoC;

namespace Cooperation.Web
{
    public class CooperationAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Cooperation";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Cooperation_default",
                "Cooperation/{controller}/{action}",
                new { action = "Index"},
                new string[] { "Cooperation.Web.Controllers" }
            );
        }
    }
}