using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseLongExtensionsTests
    {
		[Fact]
		public void ParseLong_works_with_valid_value()
        {
            Assert.Equal(1, "1".ParseLong());
            Assert.Equal(1, "1".ParseLong(NumberStyles.Integer));

            Assert.Equal(0, "0".ParseLong());
            Assert.Equal(long.MaxValue, $"{long.MaxValue}".ParseLong());
            Assert.Equal(long.MinValue, $"{long.MinValue}".ParseLong());
        }

        [Fact]
        public void ParseLong_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseLong());
        }
        
        [Fact]
        public void ParseLongOrNull_works_with_valid_value()
        {
            Assert.Equal(1, "1".ParseLongOrNull());
            Assert.Equal(1, "1".ParseLongOrNull(NumberStyles.Integer));

            Assert.Equal(0, "0".ParseLongOrNull());
            Assert.Equal(long.MaxValue, $"{long.MaxValue}".ParseLongOrNull());
            Assert.Equal(long.MinValue, $"{long.MinValue}".ParseLongOrNull());
        }

        [Fact]
        public void ParseLongOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseLongOrNull());
            Assert.Null("Z".ParseLongOrNull(NumberStyles.Integer));
        }
    }
}
