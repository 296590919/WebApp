using System;
using System.Collections.Generic;
using DataAccess.Attributes;

namespace DataAccess.Common
{
    internal static class ObjectHelper
    {
        /// <summary>
        /// 获取Entity实例的字段名和值（用于更新和插入数据）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<String,Object> GetKeyValue(Object obj){
            var data = new Dictionary<String, Object>();
            foreach (var i in obj.GetType().GetProperties())
            {
                if (!IsContainsAttribute(i.GetCustomAttributes(true)))
                {
                    var value = obj.GetType().GetProperty(i.Name).GetValue(obj, null);
                    data.Add(i.Name, value);
                }
            }
            return data;
        }

        private static bool IsContainsAttribute(object[] attrs)
        {
            foreach (var k in attrs)
            {
                if (k is IdentityAttribute)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
