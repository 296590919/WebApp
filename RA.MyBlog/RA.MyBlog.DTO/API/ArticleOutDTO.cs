using Common.DTO.Api;

namespace MyBlog.DTO.Api
{
    public class ArticleOutDTO : ApiBaseDTO
    {
        public string articleContain { get; set; }
        public string articleTitle { get; set; }
        public string articleCopyright { get; set; }
        public string articleDate { get; set; }
    }
}
