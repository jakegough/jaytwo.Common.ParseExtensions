using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseULongExtensionsTests
    {
		[Fact]
		public void ParseULong_works_with_valid_value()
        {
            Assert.Equal(1u, "1".ParseULong());
            Assert.Equal(1u, "1".ParseULong(NumberStyles.Integer));

            Assert.Equal(0u, "0".ParseULong());
            Assert.Equal(ulong.MaxValue, $"{ulong.MaxValue}".ParseULong());
            Assert.Equal(ulong.MinValue, $"{ulong.MinValue}".ParseULong());
        }

        [Fact]
        public void ParseULong_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseULong());
        }
        
        [Fact]
        public void ParseULongOrNull_works_with_valid_value()
        {
            Assert.Equal(1u, "1".ParseULongOrNull());
            Assert.Equal(1u, "1".ParseULongOrNull(NumberStyles.Integer));

            Assert.Equal(0u, "0".ParseULongOrNull());
            Assert.Equal(ulong.MaxValue, $"{ulong.MaxValue}".ParseULongOrNull());
            Assert.Equal(ulong.MinValue, $"{ulong.MinValue}".ParseULongOrNull());
        }

        [Fact]
        public void ParseULongOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseULongOrNull());
            Assert.Null("Z".ParseULongOrNull(NumberStyles.Integer));
        }
    }
}
