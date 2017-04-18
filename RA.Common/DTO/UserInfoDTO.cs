using System;

namespace Common.DTO
{
    [Serializable]
    public class UserInfoDTO
    {
        public string userName { get; set; }
        public string nickName { get; set; }
        public int userID { get; set; }
        public int userLevel { get; set; }
        public string cookiePassport { get; set; }
    }
}
