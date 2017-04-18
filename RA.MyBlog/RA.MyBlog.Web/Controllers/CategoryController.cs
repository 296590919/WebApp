using Common;
using Framework.IoC;
using MyBlog.DTO;
using MyBlog.Service.Interface;
using System.Web.Mvc;
using Common.Controllers;

namespace MyBlog.Web.Controllers
{
    public class CategoryController : BaseController
    {
        /// <summary>
        /// Category页显示
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int categoryID)
        {
            Result<ArticleListDTO> data;
            switch (categoryID)
            {
                case 0:
                    data = new Result<ArticleListDTO>() {IsSuccess = false};
                    break;
                case -999:
                    data = LocalServiceLocator.GetService<IMyBlogService>().GetNoBelongArticlesByUserID(UserObj.userID);
                    break;
                default:
                    data = LocalServiceLocator.GetService<IMyBlogService>().GetArticleListByCategoryID(categoryID);
                    break;
            }
            return View(data);
        }
        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddCategory(CategoryDTO categoryDTO)
        {
            var result = LocalServiceLocator.GetService<IMyBlogService>().AddCategory(categoryDTO);
            return new JsonResult() { Data = result };
        }
        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteCategory(int categoryID)
        {
            var result = LocalServiceLocator.GetService<IMyBlogService>().DeleteCategroy(categoryID);
            return new JsonResult() { Data = result };
        }
        /// <summary>
        /// 栏目页删除文章
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteArticle(int articleID)
        {
            var result = LocalServiceLocator.GetService<IMyBlogService>().DeleteArticleByArticleID(articleID);
            return new JsonResult() { Data = result };
        }
    }
}