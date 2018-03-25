using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseBoolExtensionsTests
    {
        [Theory]
        [InlineData(BoolStyles.OneZero, "1", true)]
        [InlineData(BoolStyles.TrueFalse | BoolStyles.OneZero, "1", true)]
        [InlineData(BoolStyles.YN, "y", true)]
        [InlineData(BoolStyles.YesNo, "yes", true)]
        [InlineData(BoolStyles.TF, "t", true)]
        [InlineData(BoolStyles.TrueFalse, "true", true)]
        public void ParseBool(BoolStyles styles, string value, bool expectedResult)
        {
            Assert.Equal(expectedResult, value.ParseBool(styles));
        }

        [Theory]
        [InlineData(BoolStyles.OneZero, "1", true)]
        [InlineData(BoolStyles.TrueFalse | BoolStyles.OneZero, "1", true)]
        [InlineData(BoolStyles.YN, "y", true)]
        [InlineData(BoolStyles.YesNo, "yes", true)]
        [InlineData(BoolStyles.TF, "t", true)]
        [InlineData(BoolStyles.TrueFalse, "true", true)]
        public void ParseBoolOrNull(BoolStyles styles, string value, bool expectedResult)
        {
            Assert.Equal(expectedResult, value.ParseBoolOrNull(styles));
        }

        [Fact]
        public void ParseBool_works_with_valid_value()
        {
            Assert.True("True".ParseBool());
            Assert.True("true".ParseBool());
            Assert.True("TRUE".ParseBool());

            Assert.True("y".ParseBool(BoolStyles.YN));

            Assert.False("False".ParseBool());
            Assert.False("false".ParseBool());
            Assert.False("FALSE".ParseBool());

            Assert.False("n".ParseBool(BoolStyles.YN));
        }

        [Fact]
        public void ParseBool_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseBool());

            Assert.Throws<FormatException>(() => "Z".ParseBool(BoolStyles.YN));
        }
        
        [Fact]
        public void ParseBoolOrNull_works_with_valid_value()
        {
            Assert.True("True".ParseBoolOrNull());
            Assert.True("true".ParseBoolOrNull());
            Assert.True("TRUE".ParseBoolOrNull());

            Assert.True("Y".ParseBoolOrNull(BoolStyles.YN));

            Assert.False("False".ParseBoolOrNull());
            Assert.False("false".ParseBoolOrNull());
            Assert.False("FALSE".ParseBoolOrNull());

            Assert.False("N".ParseBoolOrNull(BoolStyles.YN));
        }

        [Fact]
        public void ParseBoolOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseBoolOrNull());

            Assert.Null("Z".ParseBoolOrNull(BoolStyles.YN));
        }
    }
}
