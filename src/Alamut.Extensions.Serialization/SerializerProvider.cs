using System;
using Alamut.Extensions.Serialization.Providers;

namespace Alamut.Extensions.Serialization
{
    public static class SerializerProvider
    {
        private static readonly Lazy<ISerializer> LazySerializerProvider;

        static SerializerProvider() 
        {
            ISerializer InitSerializerFactory() => _default ?? (_default = new MessagePackSerializer());

            LazySerializerProvider = new Lazy<ISerializer>(InitSerializerFactory, false);
        }

        private static ISerializer _default;
        public static ISerializer Default => LazySerializerProvider.Value;

        public static void SetDefaultSerializer(SerializerProviders provider)
        {
            switch (provider)
            {
                case SerializerProviders.MessagePack:
                    _default = new MessagePackSerializer();
                    break;

                case SerializerProviders.NewtonsoftJson:
                    _default = new NewtonsoftJsonSerializer();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
            }
        }

        public static void SetDefaultSerializer(ISerializer customSerializer) => _default = customSerializer;

    }

    public enum SerializerProviders
    {
        MessagePack = 0,
        NewtonsoftJson = 1
    }
}
