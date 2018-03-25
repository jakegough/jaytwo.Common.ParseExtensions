using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseIntExtensionsTests
    {
		[Fact]
		public void ParseInt_works_with_valid_value()
        {
            Assert.Equal(1, "1".ParseInt());
            Assert.Equal(1, "1".ParseInt(NumberStyles.Integer));

            Assert.Equal(0, "0".ParseInt());
            Assert.Equal(int.MaxValue, $"{int.MaxValue}".ParseInt());
            Assert.Equal(int.MinValue, $"{int.MinValue}".ParseInt());
        }

        [Fact]
        public void ParseInt_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseInt());
        }
        
        [Fact]
        public void ParseIntOrNull_works_with_valid_value()
        {
            Assert.Equal(1, "1".ParseIntOrNull());
            Assert.Equal(1, "1".ParseIntOrNull(NumberStyles.Integer));

            Assert.Equal(0, "0".ParseIntOrNull());
            Assert.Equal(int.MaxValue, $"{int.MaxValue}".ParseIntOrNull());
            Assert.Equal(int.MinValue, $"{int.MinValue}".ParseIntOrNull());
        }

        [Fact]
        public void ParseIntOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseIntOrNull());
            Assert.Null("Z".ParseIntOrNull(NumberStyles.Integer));
        }
    }
}
