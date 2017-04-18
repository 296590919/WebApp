using Common;
using MyBlog.DTO;

namespace MyBlog.Service.Interface
{
    public partial interface IMyBlogService
    {
        Result<int> AddProject(ProjectDTO projectDTO);
        Result<int> DeleteProject(int projectID);
    }
}
