using Framework.IoC;
using MyBlog.Service.Interface;
using System.Web.Mvc;
using Common.Controllers;

namespace MyBlog.Web.Controllers
{
    public class HomeController: BaseController
    {
        /// <summary>
        /// 展示首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var data = LocalServiceLocator.GetService<IMyBlogService>().GetIndexArticleList(6, UserObj.userID);
            return View(data);
        }
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult Menu()
        {
            var data = LocalServiceLocator.GetService<IMyBlogService>().GetMenu(UserObj.userID);
            return PartialView("_AjaxMenu",data);
        }

        /// <summary>
        /// 获取项目管理对话框
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectOption()
        {
            var data = LocalServiceLocator.GetService<IMyBlogService>().GetMenu(UserObj.userID);
            return PartialView("_AjaxProjectOption", data);
        }
    }
}