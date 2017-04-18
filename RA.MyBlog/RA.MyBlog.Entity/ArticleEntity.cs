using System;
using DataAccess.Attributes;

namespace MyBlog.Entity
{
    
    [TableName("RA_MyBlog_Article")]
    public class ArticleEntity
    {
        [Primary]
        [Identity]
        public int articleID { get; set; }
        public int categoryID { get; set; }
        public string articleTitle { get; set; }
        public string articleCopyright { get; set; }
        public DateTime articleDate { get; set; }
        public string articleAbstract { get; set; }
        public string articleContain { get; set; }
        public int userID { get; set; }
    }
}
