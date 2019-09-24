using Alamut.Extensions.Serialization.Providers;

namespace Alamut.Extensions.Serialization
{
    public static class SerializerProvider
    {
        static SerializerProvider()
        {
            Default = new MessagePackSerializer();
        }

        public static ISerializer Default { get; }
    }
}
