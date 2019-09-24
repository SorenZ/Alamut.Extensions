using System.Text;
using Newtonsoft.Json;

namespace Alamut.Extensions.Serialization.Providers
{
    public class NewtonsoftJsonSerializer : ISerializer
    {
        public byte[] Serialize<T>(T obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public T Deserialize<T>(byte[] bytes)
        {
            var bytesString = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(bytesString);
        }
    }
}