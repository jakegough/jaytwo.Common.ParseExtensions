using jaytwo.Common.ParseExtensions.Parsers.BoolParsing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests.Parsers.BoolParsing
{
    public class YesNoBoolParserTests
    {
        [Theory]
        [InlineData("YES", true)]
        [InlineData("Yes", true)]
        [InlineData("yes", true)]
        [InlineData("NO", false)]
        [InlineData("No", false)]
        [InlineData("no", false)]
        void Parse_happy_path(string value, bool expected)
        {
            // arrange
            var parser = new YesNoBoolParser();

            // act
            var result = parser.Parse(value);

            // assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("YES", true, true)]
        [InlineData("Yes", true, true)]
        [InlineData("yes", true, true)]
        [InlineData("NO", true, false)]
        [InlineData("No", true, false)]
        [InlineData("no", true, false)]
        [InlineData("z", false, false)]
        void TryParse_happy_path(string value, bool expectedSuccess, bool expectedResult)
        {
            // arrange
            var parser = new YesNoBoolParser();

            // act
            var success = parser.TryParse(value, out bool result);

            // assert
            Assert.Equal(expectedSuccess, success);
            Assert.Equal(expectedResult, result);
        }
    }
}
