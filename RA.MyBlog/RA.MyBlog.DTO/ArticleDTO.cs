using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DTO
{
    public class ArticleDTO
    {
        public int userID { get; set; }
        public int articleID { get; set; }
        public string articleTitle { get; set; }
        public string articleCopyright { get; set; }
        public DateTime articleDate { get; set; }
        public string articleContain { get; set; }
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string articleAbstract { get; set; }
    }
}
