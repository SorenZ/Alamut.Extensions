// ReSharper disable MethodNameNotMeaningful

using Microsoft.AspNetCore.Http;

using Alamut.Extensions.Serialization;

namespace Alamut.Extensions.Session
{
    public static class SessionRefTypeExtensions
    {
        private static ISerializer Serializer => SerializerProvider.Default;

        public static void Set<T>(this ISession session, string key, T value) =>
            session.Set(key, Serializer.Serialize(value));

        public static T Get<T>(this ISession session, string key)
        {
            if (session.TryGetValue(key, out var value))
            {
                return Serializer.Deserialize<T>(value);
            }

            return default;
        }

        public static bool TryGetValue<T>(this ISession session, string key, out T value)
        {
            if (session.TryGetValue(key, out var internalValue))
            {
                value = Serializer.Deserialize<T>(internalValue);
                return true;
            }

            value = default;
            return false;
        }
    }
}