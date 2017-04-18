using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DTO
{
    class IndexArticleDTO
    {
        public int articleID { get; set; }
        public string articleTitle { get; set; }
        public DateTime articleDate { get; set; }
        public string articleAbstract { get; set; }
    }
}
