using Common;
using Framework.IoC;
using MyBlog.DTO;
using MyBlog.Service.Interface;
using System;
using System.Web.Mvc;
using Common.Controllers;

namespace MyBlog.Web.Controllers
{
    public class ArticleController : BaseController
    {
        /// <summary>
        /// 文章页
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Index(int articleID)
        {
            if(articleID == 0)
            {
                return View("Home");
            }
            else
            {
                var data = LocalServiceLocator.GetService<IMyBlogService>().GetArticleByArticleID(articleID);
                return View("Article",data);
            } 
        }

        /// <summary>
        /// 新建文章页
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NewArticle(int categoryID)
        {
            if(categoryID == 0)
            {
                return View("Home");
            }
            else
            {
                return View("NewArticle", categoryID);
            }
        }

        /// <summary>
        /// 提交文章
        /// </summary>
        /// <param name="articleDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult NewArticlePost(ArticleDTO articleDTO)
        {
            var result = new Result<string>();
            if(String.IsNullOrEmpty(articleDTO.articleTitle))
            {
                result.IsSuccess = false;
                result.ReturnMessage = "没有标题";
            }
            else if(String.IsNullOrEmpty(articleDTO.articleCopyright))
            {
                result.IsSuccess = false;
                result.ReturnMessage = "没有来源";
            }
            else if(String.IsNullOrEmpty(articleDTO.articleContain))
            {
                result.IsSuccess = false;
                result.ReturnMessage = "没有填写内容";
            }
            else
            {
                var data = LocalServiceLocator.GetService<IMyBlogService>().AddNewArticle(articleDTO);
                result.IsSuccess = data.IsSuccess;
                result.ReturnMessage = data.ReturnMessage;
                result.ReturnValue = data.ReturnValue.ToString();
            }
            return new JsonResult() { Data = result };
        }

        /// <summary>
        /// 编辑文章页
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Edit(int articleID)
        {
            if (articleID == 0)
            {
                return View("Home");
            }
            else
            {
                var data = LocalServiceLocator.GetService<IMyBlogService>().GetArticleByArticleID(articleID);
                return View("Edit", data);
            }
        }

        /// <summary>
        /// 编辑文章提交
        /// </summary>
        /// <param name="articleDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EditPost(ArticleDTO articleDTO)
        {
            var result = new Result<string>();
            if (String.IsNullOrEmpty(articleDTO.articleTitle))
            {
                result.IsSuccess = false;
                result.ReturnMessage = "没有标题";
            }
            else if (String.IsNullOrEmpty(articleDTO.articleCopyright))
            {
                result.IsSuccess = false;
                result.ReturnMessage = "没有来源";
            }
            else if (String.IsNullOrEmpty(articleDTO.articleContain))
            {
                result.IsSuccess = false;
                result.ReturnMessage = "没有填写内容";
            }
            else
            {
                articleDTO.userID = UserObj.userID;
                var data = LocalServiceLocator.GetService<IMyBlogService>().EditArticle(articleDTO);
                result.IsSuccess = data.IsSuccess;
                result.ReturnMessage = data.ReturnMessage;
                result.ReturnValue = data.ReturnValue.ToString();
            }
            return new JsonResult() { Data = result };
        }
    }
}