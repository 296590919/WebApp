using DataAccess.Attributes;

namespace MyBlog.Entity
{
    
    [TableName("RA_MyBlog_Category")]
    public class CategoryEntity
    {
        public int userID { get; set; }
        [Primary]
        [Identity]
        public int categoryID { get; set; }
        public int projectID { get; set; }
        public string categoryName { get; set; }
        public string categoryLogo { get; set; }
    }
}
