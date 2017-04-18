using System.ComponentModel;

namespace Framework.Logger
{
    public enum EnumServerInfoType
    {
        [Description("IoC")]
        IoC = 0,
        [Description("SqlRequest")]
        SqlRequest = 1,
    }

    public enum EnumBigEventType
    {
        [Description("Exception")]
        Exception = 0,
        [Description("ServerInfo")]
        ServerInfo = 1
    }
}
