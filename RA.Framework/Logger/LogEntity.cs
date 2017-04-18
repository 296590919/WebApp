using System;
using DataAccess.Attributes;

namespace Framework.Logger
{
    [TableName("RA_MyBlog_ServerEventLog")]
    
    public class ServerEventLogEntity
    {
        [Primary]
        [Identity]
        public int id { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string thread { get; set; }
        public DateTime time { get; set; }
        public int operatorID { get; set; }
        public string eventLevel { get; set; }
    }

    [TableName("RA_MyBlog_RequestLog")]
    
    public class RequestLogEntity
    {
        [Primary]
        [Identity]
        public int id { get; set; }
        public string method { get; set; }
        public string url { get; set; }
        public int operatorID { get; set; }
        public DateTime time { get; set; }
        public string response { get; set; }
    }
}
