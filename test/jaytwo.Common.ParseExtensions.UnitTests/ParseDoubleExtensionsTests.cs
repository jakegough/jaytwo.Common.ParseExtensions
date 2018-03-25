using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseDoubleExtensionsTests
    {
		[Fact]
		public void ParseDouble_works_with_valid_value()
        {
            Assert.Equal(1.5, "1.5".ParseDouble());
            Assert.Equal(1.5, "1.5".ParseDouble(NumberStyles.AllowDecimalPoint));

            Assert.Equal(0, "0".ParseDouble());
            Assert.Equal(double.MinValue, "-1.7976931348623157E+308".ParseDouble());
            Assert.Equal(double.MaxValue, "1.7976931348623157E+308".ParseDouble());
        }

        [Fact]
        public void ParseDouble_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseDouble());
        }
        
        [Fact]
        public void ParseDoubleOrNull_works_with_valid_value()
        {
            Assert.Equal(1.5, "1.5".ParseDoubleOrNull());
            Assert.Equal(1.5, "1.5".ParseDoubleOrNull(NumberStyles.AllowDecimalPoint));

            Assert.Equal(0, "0".ParseDoubleOrNull());
            Assert.Equal(double.MinValue, "-1.7976931348623157E+308".ParseDoubleOrNull());
            Assert.Equal(double.MaxValue, "1.7976931348623157E+308".ParseDoubleOrNull());
        }

        [Fact]
        public void ParseDoubleOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseDoubleOrNull());
            Assert.Null("Z".ParseDoubleOrNull(NumberStyles.AllowDecimalPoint));
        }
    }
}
