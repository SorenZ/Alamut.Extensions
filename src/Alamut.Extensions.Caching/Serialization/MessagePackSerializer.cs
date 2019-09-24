using System;
using MessagePack.Resolvers;


namespace Alamut.Extensions.Caching.Serialization
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

        public byte[] Serialize<T>(T obj) => 
            MessagePack.MessagePackSerializer.Serialize(obj);

        public T Deserialize<T>(byte[] bytes) => 
            MessagePack.MessagePackSerializer.Deserialize<T>(bytes);
    }
}