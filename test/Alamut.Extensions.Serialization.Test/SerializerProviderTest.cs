using System;
using Alamut.Extensions.Serialization.Providers;
using Xunit;

namespace Alamut.Extensions.Serialization.Test
{
    public class SerializerProviderTest
    {
        [Fact]
        public void SerializerProvider_Init_SetDefaultSerializer()
        {
            // arrange
            var actual = new MessagePackSerializer();
            
            // act
            var expected = SerializerProvider.Default;

            // assert
            Assert.Equal(expected.GetType(), actual.GetType());
        }

        [Fact]
        public void SerializerProvider_SetDefaultSerializer_ShouldChangeProvider()
        {
            // arrange
            var actual = new NewtonsoftJsonSerializer();
            
            // act
            SerializerProvider.SetDefaultSerializer(SerializerProviders.NewtonsoftJson);
            var expected = SerializerProvider.Default;

            // assert
            Assert.Equal(expected.GetType(), actual.GetType());
        }
    }
}
