using System.Web.Script.Serialization;

namespace Common
{
    public class Serializer
    {
        public static string Serialize<T>(Result<T> obj)
        {
            var json = new JavaScriptSerializer().Serialize(obj);
            return json;
        }

        public static T Deserialize<T>(string json)
        {
            var obj = new JavaScriptSerializer().Deserialize<T>(json);
            return obj;
        }
    }
}
