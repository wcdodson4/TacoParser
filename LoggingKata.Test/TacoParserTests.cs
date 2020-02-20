using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", 34.073638, -84.677017, "Taco Bell Acwort...")]
        public void ShouldParse(string str, double expectedLat, double expectedLong, string expectedName)
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(str);
            
            Assert.Equal(actual.Location.Longitude, expectedLong);
            Assert.Equal(actual.Location.Latitude, expectedLat);
            Assert.Equal(actual.Name, expectedName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse(str);

            Assert.Null(actual);
        }
    }
}
