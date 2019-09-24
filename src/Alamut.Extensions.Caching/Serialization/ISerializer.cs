namespace Alamut.Extensions.Caching.Serialization
{
    public interface ISerializer
    {
        byte[] Serialize<T>(T obj);
        
        T Deserialize<T>(byte[] bytes);
    }
}
