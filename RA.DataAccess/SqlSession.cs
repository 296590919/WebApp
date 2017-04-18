using System.Collections.Generic;
using DataAccess.Common;

namespace DataAccess
{
    public partial class SqlSession<T>
    {
        public SqlSession()
        {
            Fields = EntityHelper.GetFields<T>(false);
            Field = EntityHelper.GetFiledString<T>();
            TableName = EntityHelper.GetTableName<T>();
            PrimaryKey = EntityHelper.GetPrimaryKey<T>();
        }
        public string Field { get; set; }
        public string PrimaryKey { get; set; }
        public string TableName { get; set; }
        public List<string> Fields { get; set; }
        public string WhereStr { get; set; } = "";
        public string SelectExpression { get; set; }
        public bool IsDistinct { get; set; }
        public string OrderByStr { get; set; }
        public string JoinStr { get; set; }
        public string SqlExpression
        {
            get
            {
                var sql = "SELECT $distinct " + Field + " FROM " + TableName + " $join$where$orderby";

                sql = sql.Replace("$distinct", IsDistinct ? "DISTINCT" : "");
                sql = sql.Replace("$join", string.IsNullOrEmpty(JoinStr) ? "" : JoinStr);
                sql = sql.Replace("$where", string.IsNullOrEmpty(WhereStr) ? "" : "WHERE " + WhereStr);
                sql = sql.Replace("$orderby", string.IsNullOrEmpty(OrderByStr) ? "" : "ORDER BY " + OrderByStr);
                return sql;
            }
        }
    }


}
