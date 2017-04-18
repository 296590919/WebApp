using Common;
using MyBlog.DTO;

namespace MyBlog.Service.Interface
{
    public partial interface IMyBlogService
    {
        Result<ArticleListDTO> GetArticleListByCategoryID(int categoryID);
        Result<string> GetCategoryNameByArticleID(int articleID);
        Result<string> GetCategoryNameByCategoryID(int categoryID);
        Result<int> AddCategory(CategoryDTO dto);
        Result<int> DeleteCategroy(int categroyID);
        Result<ArticleListDTO> GetNoBelongArticlesByUserID(int userID);
    }
}
