using System;
using System.Collections.Generic;
using System.Text;
using Alamut.Extensions.Serialization.Providers;
using Alamut.Extensions.Serialization.Test.Helpers;
using Xunit;

namespace Alamut.Extensions.Serialization.Test.Providers
{
    public class MessagePackSerializerTest
    {
        [Fact]
        public void MessagePack_SerializeAndDeSerialize_ReturnSame()
        {
            // arrange
            var sut = new MessagePackSerializer();
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
