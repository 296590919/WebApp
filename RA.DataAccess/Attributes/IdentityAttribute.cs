using System;

namespace DataAccess.Attributes
{
    /// <summary>
    /// 递增键
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class IdentityAttribute:Attribute
    {
    }
}
