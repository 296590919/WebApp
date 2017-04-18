using Framework.IoC;
using MyBlog.DTO;
using MyBlog.Service.Interface;
using System.Web.Mvc;
using Common.Controllers;

namespace MyBlog.Web.Controllers
{
    public class ProjectController : BaseController
    {
        // GET: Project
        public JsonResult AddProject(ProjectDTO projectDTO)
        {
            var data = LocalServiceLocator.GetService<IMyBlogService>().AddProject(projectDTO);
            return new JsonResult() { Data = data };
        }

        public JsonResult DeleteProject(int projectID)
        {
            var data = LocalServiceLocator.GetService<IMyBlogService>().DeleteProject(projectID);
            return new JsonResult() { Data = data };
        }
    }
}