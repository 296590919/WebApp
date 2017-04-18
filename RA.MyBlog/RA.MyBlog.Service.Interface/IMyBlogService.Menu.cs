using Common;
using MyBlog.DTO;
using System.Collections.Generic;

namespace MyBlog.Service.Interface
{
    public partial interface IMyBlogService
    {
        Result<List<MenuDTO>> GetMenu(int userID);
    }
}
