using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Attributes;

namespace DataAccess.Common
{
    internal static class EntityHelper
    {

        public static List<String> GetDTOFields<T>()
        {
            var fields = typeof(T).GetProperties();
            var result = new List<String>();
            foreach (var i in fields)
            {
                result.Add(i.Name);
            }
            return result;
        }

        /// <summary>
        /// 获取Entity实体中的字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="isFullName">true：字段名前面包含表名</param>
        /// <returns></returns>
        public static List<String> GetFields<T>(Boolean isFullName)
        {
            var fields = typeof(T).GetProperties();
            var result = new List<String>();
            if (isFullName)
            {
                var tablename = EntityHelper.GetTableName<T>();
                foreach (var i in fields)
                {
                    result.Add(tablename + "." + i.Name);
                }
                return result;
            }
            else
            {
                foreach (var i in fields)
                {
                    result.Add(i.Name);
                }
                return result;
            }
            
        }

        public static String GetFiledString<T>()
        {
            var list = GetFields<T>(true).ToArray();
            var result = String.Join(",", list);
            return result;
        }

        /// <summary>
        /// 获取实体代表的表名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static String GetTableName<T>()
        {
            var tablename = typeof(T).GetCustomAttributes(typeof(TableNameAttribute), true);
            return ((TableNameAttribute)tablename[0]).TableName;
        }

        public static String GetTableName(Type entityType)
        {
            try
            {
                var tablename = entityType.GetCustomAttributes(typeof(TableNameAttribute), true);
                return ((TableNameAttribute)tablename[0]).TableName;
            }
            catch
            {
                throw new Exception("没有配置TableName特性！");
            }
            
        }

        /// <summary>
        /// 获取实体主键名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static String GetPrimaryKey<T>()
        {
            var primary = typeof(T).GetCustomAttributes(typeof(PrimaryAttribute), true);
            var pri = typeof(T).GetProperties();
            foreach (var i in pri)
            {
                var pris = i.GetCustomAttributes(typeof(PrimaryAttribute), true);
                if (pris.Count() >= 1)
                {
                    return i.Name;
                }
            }
            return "";     
        }
    }
}
