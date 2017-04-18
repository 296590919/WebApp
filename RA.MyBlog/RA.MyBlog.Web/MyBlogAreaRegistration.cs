using Framework.IoC;
using MyBlog.Service.Interface;
using System.Web.Mvc;

namespace MyBlog.Web
{
    public class MyBlogAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get
            {
                return "MyBlog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MyBlog_default",
                "MyBlog/{controller}/{action}",
                new { action = "Index"},
                new string[] { "MyBlog.Web.Controllers" }
            );
        }
    }
}