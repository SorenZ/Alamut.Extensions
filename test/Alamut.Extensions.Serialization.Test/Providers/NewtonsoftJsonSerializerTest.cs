using System;

using Alamut.Extensions.Serialization.Providers;
using Alamut.Extensions.Serialization.Test.Helpers;

using Xunit;

namespace Alamut.Extensions.Serialization.Test.Providers
{
    public class NewtonsoftJsonSerializerTest
    {
        [Fact]
        public void MessagePack_SerializeAndDeSerialize_ReturnSame()
        {
            // arrange
            var sut = new NewtonsoftJsonSerializer();
            var actual = new RefTypeObject
            {
                foo = 1,
                bar = "test", 
                Created = DateTime.UtcNow
            };

            // act
            var bytes = sut.Serialize(actual);
            var expected = sut.Deserialize<RefTypeObject>(bytes);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
