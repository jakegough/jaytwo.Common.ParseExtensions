using jaytwo.Common.ParseExtensions.Parsers.BoolParsing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests.Parsers.BoolParsing
{
    public class YNBoolParserTests
    {
        [Theory]
        [InlineData("Y", true)]
        [InlineData("y", true)]
        [InlineData("N", false)]
        [InlineData("n", false)]
        void Parse_happy_path(string value, bool expected)
        {
            // arrange
            var parser = new YNBoolParser();

            // act
            var result = parser.Parse(value);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Y", true, true)]
        [InlineData("y", true, true)]
        [InlineData("N", true, false)]
        [InlineData("n", true, false)]
        [InlineData("z", false, false)]
        void TryParse_happy_path(string value, bool expectedSuccess, bool expectedResult)
        {
            // arrange
            var parser = new YNBoolParser();

            // act
            var success = parser.TryParse(value, out bool result);

            // assert
            Assert.Equal(expectedSuccess, success);
            Assert.Equal(expectedResult, result);
        }
    }
}
