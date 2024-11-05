using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebPhone.Extensions
{
    public static class SessionExtensions
    {
        // Phương thức mở rộng để lưu đối tượng vào session dưới dạng JSON
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Phương thức mở rộng để lấy đối tượng từ session
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

    }
}
