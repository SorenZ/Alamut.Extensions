using MessagePack.Resolvers;

namespace Alamut.Extensions.Serialization.Providers
{
    public class MessagePackSerializer : ISerializer
    {

        public MessagePackSerializer()
        {
            CompositeResolver.RegisterAndSetAsDefault(
                new[]
                {
                    NativeDateTimeResolver.Instance,
                    ContractlessStandardResolver.Instance
                });
        }

        public MessagePackSerializer(bool callDefaultRegistration)
        {
            // test purpose 
        }

        public byte[] Serialize<T>(T obj) => 
            MessagePack.MessagePackSerializer.Serialize(obj);

        public T Deserialize<T>(byte[] bytes) => 
            MessagePack.MessagePackSerializer.Deserialize<T>(bytes);
    }
}