using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using DataAccess.Common;

namespace DataAccess.MySqlDbUtility
{
    public partial class DbUtility : IDbUtility
    {
        private MySqlConnection conn;
        private MySqlDataAdapter da;
        private readonly string connectionString;

        private DbUtility()
        {
            connectionString = ConfigurationManager.AppSettings["MySql"];
        }
        private static DbUtility _dbUtility;

        public static DbUtility GetInstance()
        {
            return _dbUtility ?? (_dbUtility = new DbUtility());
        }

        /// <summary>
        /// 为通过反射生成的实例赋值
        /// </summary>
        /// <typeparam name="T">实例的类型</typeparam>
        /// <param name="obj">实例</param>
        /// <param name="value">值</param>
        /// <param name="key">成员名称</param>
        private void SetValue<T>(ref T obj, Object value, String key) where T : class
        {
            var property = obj.GetType().GetProperty(key);
            var type = property.PropertyType.Name;
            if (value is System.DBNull)
            {
                property.SetValue(obj, null, null);
                return;
            }
            switch (type)
            {
                case "Int32":
                    property.SetValue(obj, int.Parse(value.ToString()), null);
                    break;
                case "String":
                    property.SetValue(obj, value.ToString(), null);
                    break;
                case "DateTime":
                    property.SetValue(obj, (DateTime)value, null);
                    break;
                default:
                    property.SetValue(obj, value, null);
                    break;
            }
        }
        /// <summary>
        /// 获得SQLSession实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public SqlSession<T> GetSqlExpression<T>() where T : class
        {
            var temp = new SqlSession<T>();
            conn = new MySqlConnection(connectionString);
            return temp;
        }
    }
}
