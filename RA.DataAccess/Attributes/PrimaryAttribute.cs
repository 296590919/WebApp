using System;

namespace DataAccess.Attributes
{
    /// <summary>
    /// 主键
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class PrimaryAttribute : Attribute
    {
        
    }
}
