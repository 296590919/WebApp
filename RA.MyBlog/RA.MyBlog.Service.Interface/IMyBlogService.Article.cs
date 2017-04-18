using Common;
using MyBlog.DTO;
using System.Collections.Generic;

namespace MyBlog.Service.Interface
{
    public partial interface IMyBlogService
    {
        Result<ArticleDTO> GetArticleByArticleID(int articleID);
        Result<int> AddNewArticle(ArticleDTO dto);
        Result<int> EditArticle(ArticleDTO dto);
        Result<int> DeleteArticleByArticleID(int articleID);
        Result<List<ArticleDTO>> GetIndexArticleList(int count,int userID);
    }
}
