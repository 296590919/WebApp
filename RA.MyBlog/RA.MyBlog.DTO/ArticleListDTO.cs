using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DTO
{
    public class ArticleListItemDTO
    {
        public string articleTitle { get; set; }
        public int articleID { get; set; }
        public string articleCopyright { get; set; }
        public DateTime articleDate { get; set; }
    }

    public class ArticleListDTO
    {
        public List<ArticleListItemDTO> ArticleList { get; set; }
        public int categoryID { get; set; }
        public string categoryName { get; set; }

    }
}
