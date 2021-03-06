﻿using MessagePack.Resolvers;

namespace Alamut.Extensions.Serialization.Providers
{
    public class MessagePackSerializer : ISerializer
    {
        static MessagePackSerializer()
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