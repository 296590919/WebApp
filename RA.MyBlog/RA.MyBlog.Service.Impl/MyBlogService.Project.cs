using MyBlog.Service.Interface;
using MyBlog.DTO;
using MyBlog.Entity;
using Common;
using DataAccess;

namespace MyBlog.Service.Impl
{
    public partial class MyBlogService : IMyBlogService
    {
        public Result<int> AddProject(ProjectDTO projectDTO)
        {
            var result = DbUtilityFactory.GetDbUtility().Add(new ProjectEntity()
            {
                projectName = projectDTO.projectName,
                userID = projectDTO.userID
            });
            if(result == 1)
            {
                return new Result<int>()
                {
                    IsSuccess = true,
                    ReturnValue = result,
                    ReturnMessage = "添加成功"
                };
            }else
            {
                return new Result<int>()
                {
                    IsSuccess = false,
                    ReturnMessage = "添加失败"
                };
            }
            
        }

        public Result<int> DeleteProject(int projectID)
        {
            var result = DbUtilityFactory.GetDbUtility().Delete<ProjectEntity>(a => a.projectID == projectID);
            if (result == 1)
            {
                return new Result<int>()
                {
                    IsSuccess = true,
                    ReturnValue = result,
                    ReturnMessage = "删除成功"
                };
            }
            else
            {
                return new Result<int>()
                {
                    IsSuccess = false,
                    ReturnMessage = "删除失败"
                };
            }
        }
    }
}
