using jaytwo.Common.ParseExtensions.Parsers.BoolParsing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests.Parsers.BoolParsing
{
    public class TFBoolParserTests
    {
        [Theory]
        [InlineData("T", true)]
        [InlineData("t", true)]
        [InlineData("F", false)]
        [InlineData("f", false)]
        void Parse_happy_path(string value, bool expected)
        {
            // arrange
            var parser = new TFBoolParser();

            // act
            var result = parser.Parse(value);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("T", true, true)]
        [InlineData("t", true, true)]
        [InlineData("F", true, false)]
        [InlineData("f", true, false)]
        [InlineData("z", false, false)]
        void TryParse_happy_path(string value, bool expectedSuccess, bool expectedResult)
        {
            // arrange
            var parser = new TFBoolParser();

            // act
            var success = parser.TryParse(value, out bool result);

            // assert
            Assert.Equal(expectedSuccess, success);
            Assert.Equal(expectedResult, result);
        }
    }
}
