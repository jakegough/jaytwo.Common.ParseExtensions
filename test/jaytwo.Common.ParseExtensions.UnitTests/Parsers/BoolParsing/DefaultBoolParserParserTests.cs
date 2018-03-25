using jaytwo.Common.ParseExtensions.Parsers.BoolParsing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests.Parsers.BoolParsing
{
    public class DefaultBoolParserParserTests
    {
        [Theory]
        [InlineData("TRUE", true)]
        [InlineData("True", true)]
        [InlineData("true", true)]
        [InlineData("FALSE", false)]
        [InlineData("False", false)]
        [InlineData("false", false)]
        void Parse_happy_path(string value, bool expected)
        {
            // arrange
            var parser = new DefaultBoolParser();

            // act
            var result = parser.Parse(value);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("TRUE", true, true)]
        [InlineData("True", true, true)]
        [InlineData("true", true, true)]
        [InlineData("FALSE", true, false)]
        [InlineData("False", true, false)]
        [InlineData("false", true, false)]
        [InlineData("z", false, false)]
        void TryParse_happy_path(string value, bool expectedSuccess, bool expectedResult)
        {
            // arrange
            var parser = new DefaultBoolParser();

            // act
            var success = parser.TryParse(value, out bool result);

            // assert
            Assert.Equal(expectedSuccess, success);
            Assert.Equal(expectedResult, result);
        }
    }
}
