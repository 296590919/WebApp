using MyBlog.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using MyBlog.DTO;
using MyBlog.Entity;
using DataAccess;
using Common;

namespace MyBlog.Service.Impl
{
    public partial class MyBlogService : IMyBlogService
    {
        public Result<List<MenuDTO>> GetMenu(int userID)
        {
            var pexp = DbUtilityFactory.GetDbUtility().GetSqlExpression<ProjectEntity>();
            pexp.Where(a => a.userID == userID);
            var projects = DbUtilityFactory.GetDbUtility().GetList(pexp);
            var menuList = new List<MenuDTO>();

            foreach(var i in projects)
            {
                var cexp = DbUtilityFactory.GetDbUtility().GetSqlExpression<CategoryEntity>();
                var projectID = i.projectID;
                cexp.Where(a => a.projectID == projectID);
                var categories = DbUtilityFactory.GetDbUtility().GetList(cexp);

                menuList.Add(new MenuDTO()
                {
                    projectID = i.projectID,
                    projectName = i.projectName,
                    categoryList = categories.Select<CategoryEntity, MenuItemDTO>(a => new MenuItemDTO()
                    {
                        categoryID = a.categoryID,
                        categoryName = a.categoryName
                    }).ToList()
                });
            }
            return new Result<List<MenuDTO>>()
            {
                IsSuccess = true,
                ReturnValue = menuList,
                ReturnMessage = "成功"
            };
        }
    }
}
