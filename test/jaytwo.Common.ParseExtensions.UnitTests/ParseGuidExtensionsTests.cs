using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseGuidExtensionsTests
    {
        [Theory]
        [InlineData("7d33b305-14c0-4edc-816f-3cb22144aa63")]
        [InlineData("{7d33b305-14c0-4edc-816f-3cb22144aa63}")]
        void ParseGuid_returns_parsed_guid(string guidString)
        {
            // act
            var result = guidString.ParseGuid();

            // assert
            Assert.Equal(new Guid(guidString), result);
        }

        [Fact]
        void ParseGuid_throws_exception_for_bad_guid()
        {
            // arrange
            var guidString = "x";

            // act & assert
            Assert.Throws<FormatException>(() => guidString.ParseGuid());
        }

        [Theory]
        [InlineData("7d33b305-14c0-4edc-816f-3cb22144aa63")]
        [InlineData("{7d33b305-14c0-4edc-816f-3cb22144aa63}")]
        void ParseGuidOrNull_returns_parsed_guid(string guidString)
        {
            // act
            var result = guidString.ParseGuidOrNull();

            // assert
            Assert.Equal(new Guid(guidString), result);
        }

        [Fact]
        void ParseGuidOrNull_returns_null_for_bad_guid()
        {
            // arrange
            var guidString = "x";

            // act
            var result = guidString.ParseGuidOrNull();

            // assert
            Assert.Null(result);
        }
    }
}
