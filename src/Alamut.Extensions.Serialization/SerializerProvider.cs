using System;
using Alamut.Extensions.Serialization.Providers;

namespace Alamut.Extensions.Serialization
{
    public static class SerializerProvider
    {
        static SerializerProvider()
        {
            SetDefaultSerializer(SerializerProviders.MessagePack);
        }

        public static ISerializer Default { get; private set; }

        public static void SetDefaultSerializer(SerializerProviders provider)
        {
            switch (provider)
            {
                case SerializerProviders.MessagePack:
                    Default = new MessagePackSerializer();
                    break;

                case SerializerProviders.NewtonsoftJson:
                    Default = new NewtonsoftJsonSerializer();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
            }
        }

        public static void SetDefaultSerializer(ISerializer customSerializer) => Default = customSerializer;
    }

    public enum SerializerProviders
    {
        MessagePack = 0,
        NewtonsoftJson = 1
    }
}
