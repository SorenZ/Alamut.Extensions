namespace Alamut.Extensions.Caching.Serialization
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
