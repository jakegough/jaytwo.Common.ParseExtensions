using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseShortExtensionsTests
    {
		[Fact]
		public void ParseShort_works_with_valid_value()
        {
            Assert.Equal(1, "1".ParseShort());
            Assert.Equal(1, "1".ParseShort(NumberStyles.Integer));

            Assert.Equal(0, "0".ParseShort());
            Assert.Equal(short.MaxValue, $"{short.MaxValue}".ParseShort());
            Assert.Equal(short.MinValue, $"{short.MinValue}".ParseShort());
        }

        [Fact]
        public void ParseShort_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseShort());
        }
        
        [Fact]
        public void ParseShortOrNull_works_with_valid_value()
        {
            Assert.Equal((short)1, "1".ParseShortOrNull());
            Assert.Equal((short)1, "1".ParseShortOrNull(NumberStyles.Integer));

            Assert.Equal((short)0, "0".ParseShortOrNull());
            Assert.Equal(short.MaxValue, $"{short.MaxValue}".ParseShortOrNull());
            Assert.Equal(short.MinValue, $"{short.MinValue}".ParseShortOrNull());
        }

        [Fact]
        public void ParseShortOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseShortOrNull());
            Assert.Null("Z".ParseShortOrNull(NumberStyles.Integer));
        }
    }
}
