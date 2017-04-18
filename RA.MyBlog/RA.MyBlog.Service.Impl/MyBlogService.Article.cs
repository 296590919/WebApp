using MyBlog.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using MyBlog.DTO;
using MyBlog.Entity;
using Framework.IoC;
using DataAccess;
using Common;

namespace MyBlog.Service.Impl
{
    public partial class MyBlogService : IMyBlogService
    {
        public Result<int> AddNewArticle(ArticleDTO dto)
        {
            var result = DbUtilityFactory.GetDbUtility().Add(new ArticleEntity()
            {
                categoryID = dto.categoryID,
                articleAbstract = dto.articleAbstract,
                articleContain = dto.articleContain,
                articleCopyright = dto.articleCopyright,
                articleDate = DateTime.Now,
                articleTitle = dto.articleTitle,
                userID = dto.userID
            });
            if(result > 0)
            {
                return new Result<int>()
                {
                    ReturnMessage = "添加成功",
                    IsSuccess = true,
                    ReturnValue = result
                };
            }else
            {
                return new Result<int>()
                {
                    ReturnMessage = "添加失败",
                    IsSuccess = false,
                    ReturnValue = result
                };
            }
        }

        public Result<int> DeleteArticleByArticleID(int articleID)
        {
            var result = DbUtilityFactory.GetDbUtility().Delete<ArticleEntity>(a => a.articleID == articleID);
            if(result == 1)
            {
                return new Result<int>()
                {
                    ReturnMessage = "删除成功",
                    IsSuccess = true,
                    ReturnValue = result
                };
            }
            else
            {
                return new Result<int>()
                {
                    ReturnMessage = "删除失败",
                    IsSuccess = false,
                    ReturnValue = result
                };
            }
        }

        public Result<int> EditArticle(ArticleDTO dto)
        {
            var result = DbUtilityFactory.GetDbUtility().Update(new ArticleEntity()
            {
                articleID = dto.articleID,
                articleAbstract = dto.articleAbstract,
                articleContain = dto.articleContain,
                articleCopyright = dto.articleCopyright,
                articleDate = DateTime.Now,
                articleTitle = dto.articleTitle,
                categoryID = dto.categoryID,
                userID = dto.userID
            }, a => a.articleID == dto.articleID);

            if (result == 1)
            {
                return new Result<int>()
                {
                    ReturnMessage = "修改成功",
                    IsSuccess = true,
                    ReturnValue = result
                };
            }
            else
            {
                return new Result<int>()
                {
                    ReturnMessage = "修改失败",
                    IsSuccess = false,
                    ReturnValue = result
                };
            }
        }

        public Result<ArticleDTO> GetArticleByArticleID(int articleID)
        {
            var data = DbUtilityFactory.GetDbUtility().GetSingle<ArticleEntity>(a => a.articleID == articleID);
            if(data != null)
            {
                return new Result<ArticleDTO>()
                {
                    IsSuccess = true,
                    ReturnMessage = "成功",
                    ReturnValue = new ArticleDTO()
                    {
                        articleAbstract = data.articleAbstract,
                        articleContain = data.articleContain,
                        articleCopyright = data.articleCopyright,
                        articleDate = data.articleDate,
                        articleID = articleID,
                        articleTitle = data.articleTitle,
                        categoryID = data.categoryID,
                        categoryName = LocalServiceLocator.GetService<IMyBlogService>().GetCategoryNameByCategoryID(data.categoryID).ReturnValue,
                        userID = data.userID
                    }
                };
            }else
            {
                return new Result<ArticleDTO>()
                {
                    IsSuccess = false,
                    ReturnMessage = "没有找到文章"
                };
            }
        }

        public Result<List<ArticleDTO>> GetIndexArticleList(int count, int userID)
        {
            var exp = DbUtilityFactory.GetDbUtility().GetSqlExpression<ArticleEntity>();
            exp.Where(a => a.userID == userID);
            exp.OrderByDescending(a=>a.articleDate);
            var data = DbUtilityFactory.GetDbUtility().Paged<ArticleEntity>(a=>a.articleDate,1,6);
            if(data.Any())
            {
                return new Result<List<ArticleDTO>>()
                {
                    IsSuccess = true,
                    ReturnMessage = "成功",
                    ReturnValue = data.Select<ArticleEntity, ArticleDTO>(a => new ArticleDTO()
                    {
                        articleAbstract = a.articleAbstract,
                        articleDate = a.articleDate,
                        articleID = a.articleID,
                        articleTitle = a.articleTitle
                    }).ToList()
                };
            }else
            {
                return new Result<List<ArticleDTO>>()
                {
                    IsSuccess = false,
                    ReturnMessage = "没有记录"
                };
            }
        }
    }
}
