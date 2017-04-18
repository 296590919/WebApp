using DataAccess.Attributes;

namespace MyBlog.Entity
{
    
    [TableName("RA_MyBlog_Project")]
    public class ProjectEntity
    {
        [Primary]
        [Identity]
        public int projectID { get; set; }
        public string projectName { get; set; }
        public int userID { get; set; }
    }
}
