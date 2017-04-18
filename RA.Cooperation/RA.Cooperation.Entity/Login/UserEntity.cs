using DataAccess.Attributes;

namespace Cooperation.Entity.Login
{
    
    [TableName("RA_MyBlog_User")]
    public class UserEntity
    {
        [Primary]
        [Identity]
        public int userID { get; set; }
        public string userName { get; set; }
        public string passwordMd5 { get; set; }
        public string userNameMd5 { get; set; }
        public int userLevel { get; set; }
        public string nickName { get; set; }
    }
}
