using System.Web.Script.Serialization;

namespace Ruanmou.Common
{
    public class JsonHelper
    {
        public static string ObjToString(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static T JsonToObj<T>(string jsonObject) 
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(jsonObject);
        }
    }
}