using MyBlog.Service.Interface;
using System;
using System.Linq;
using MyBlog.DTO;
using MyBlog.Entity;
using DataAccess;
using Common;

namespace MyBlog.Service.Impl
{
    public partial class MyBlogService : IMyBlogService
    {
        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>成功返回"成功"，失败返回"添加失败"，成功与否都会返回受影响条数</returns>
        public Result<int> AddCategory(CategoryDTO dto)
        {
            var result = DbUtilityFactory.GetDbUtility().Add<CategoryEntity>(new CategoryEntity()
            {
                categoryName = dto.categoryName,
                projectID = dto.projectID,
                userID = dto.userID
            });
            if(result == 1)
            {
                return new Result<int>()
                {
                    IsSuccess = true,
                    ReturnMessage = "成功",
                    ReturnValue = result
                };
            }else
            {
                return new Result<int>()
                {
                    IsSuccess = false,
                    ReturnMessage = "添加失败",
                    ReturnValue = result
                };
            }
        }

        public Result<int> DeleteCategroy(int categroyID)
        {
            var result = DbUtilityFactory.GetDbUtility().Delete<CategoryEntity>(a=>a.categoryID == categroyID);
            if (result == 1)
            {
                return new Result<int>()
                {
                    IsSuccess = true,
                    ReturnMessage = "成功",
                    ReturnValue = result
                };
            }
            else
            {
                return new Result<int>()
                {
                    IsSuccess = false,
                    ReturnMessage = "删除失败",
                    ReturnValue = result
                };
            }
        }

        public Result<ArticleListDTO> GetArticleListByCategoryID(int categoryID)
        {
            var exp = DbUtilityFactory.GetDbUtility().GetSqlExpression<ArticleEntity>();
            exp.Where(a => a.categoryID == categoryID);
            var data = DbUtilityFactory.GetDbUtility().GetList(exp);
            if(data == null)
            {
                return new Result<ArticleListDTO>()
                {
                    IsSuccess = false,
                    ReturnMessage = "出现错误"
                };
            }
            if (!data.Any())
            {
                return new Result<ArticleListDTO>()
                {
                    IsSuccess = true,
                    ReturnMessage = "没有找到记录",
                    ReturnValue = new ArticleListDTO()
                    {
                        categoryID = categoryID,
                        categoryName = GetCategoryNameByCategoryID(categoryID).ReturnValue
                    }
                };
            }
            else
            {
                return new Result<ArticleListDTO>()
                {
                    IsSuccess = true,
                    ReturnMessage = "成功",
                    ReturnValue = new ArticleListDTO()
                    {
                        categoryID = categoryID,
                        categoryName = GetCategoryNameByCategoryID(categoryID).ReturnValue,
                        ArticleList = data.Select<ArticleEntity, ArticleListItemDTO>(a => new ArticleListItemDTO()
                        {
                            articleCopyright = a.articleCopyright,
                            articleDate = a.articleDate,
                            articleID = a.articleID,
                            articleTitle = a.articleTitle
                        }).ToList()
                    }
                };
            }
        }

        public Result<string> GetCategoryNameByArticleID(int articleID)
        {
            var exp = DbUtilityFactory.GetDbUtility().GetSqlExpression<CategoryEntity>();
            exp.LeftJoin<ArticleEntity>((a, b) => a.categoryID == b.categoryID);
            exp.Where<ArticleEntity>(a => a.articleID == articleID);
            var data = DbUtilityFactory.GetDbUtility().GetList(exp);
            if (data == null)
            {
                return new Result<string>()
                {
                    IsSuccess = false,
                    ReturnMessage = "出现错误"
                };
            }
            if (data.Any())
            {
                return new Result<string>()
                {
                    IsSuccess = true,
                    ReturnMessage = "成功",
                    ReturnValue = data.First().categoryName
                };
            }
            else
            {
                return new Result<string>()
                {
                    IsSuccess = false,
                    ReturnMessage = "没有找到栏目名称"
                };
            }
        }

        public Result<string> GetCategoryNameByCategoryID(int categoryID)
        {
            var result = DbUtilityFactory.GetDbUtility().Scala<CategoryEntity, string>(a => a.categoryName, a => a.categoryID == categoryID);
            if (!String.IsNullOrEmpty(result))
            {
                return new Result<string>()
                {
                    IsSuccess = true,
                    ReturnMessage = "成功",
                    ReturnValue = result
                };
            }else
            {
                return new Result<string>()
                {
                    IsSuccess = false,
                    ReturnMessage = "没有找到栏目名称"
                };
            }
        }

        public Result<ArticleListDTO> GetNoBelongArticlesByUserID(int userID)
        {
            var exp = DbUtilityFactory.GetDbUtility().GetSqlExpression<ArticleEntity>();
            exp.Where(a => a.userID == userID && a.categoryID == -999);
            var data = DbUtilityFactory.GetDbUtility().GetList(exp);
            if (data == null)
            {
                return new Result<ArticleListDTO>()
                {
                    IsSuccess = false,
                    ReturnMessage = "出现错误"
                };
            }
            if (data.Any())
            {
                return new Result<ArticleListDTO>()
                {
                    IsSuccess = true,
                    ReturnMessage = "成功",
                    ReturnValue = new ArticleListDTO()
                    {
                        categoryID = -999,
                        ArticleList = data.Select<ArticleEntity, ArticleListItemDTO>(a => new ArticleListItemDTO()
                        {
                            articleCopyright = a.articleCopyright,
                            articleDate = a.articleDate,
                            articleID = a.articleID,
                            articleTitle = a.articleTitle
                        }).ToList()
                    }
                };
            }
            else
            {
                return new Result<ArticleListDTO>()
                {
                    IsSuccess = true,
                    ReturnMessage = "没有找到记录",
                    ReturnValue = new ArticleListDTO()
                    {
                        categoryID = -999,
                        categoryName = "未分类"
                    }
                };
            }

        }
    }
}
