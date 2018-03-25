using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseUShortExtensionsTests
    {
		[Fact]
		public void ParseUShort_works_with_valid_value()
        {
            Assert.Equal(1, "1".ParseUShort());
            Assert.Equal(1, "1".ParseUShort(NumberStyles.Integer));

            Assert.Equal(0, "0".ParseUShort());
            Assert.Equal(ushort.MaxValue, $"{ushort.MaxValue}".ParseUShort());
            Assert.Equal(ushort.MinValue, $"{ushort.MinValue}".ParseUShort());
        }

        [Fact]
        public void ParseUShort_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseUShort());
        }
        
        [Fact]
        public void ParseUShortOrNull_works_with_valid_value()
        {
            Assert.Equal((ushort)1, "1".ParseUShortOrNull());
            Assert.Equal((ushort)1, "1".ParseUShortOrNull(NumberStyles.Integer));

            Assert.Equal((ushort)0, "0".ParseUShortOrNull());
            Assert.Equal(ushort.MaxValue, $"{ushort.MaxValue}".ParseUShortOrNull());
            Assert.Equal(ushort.MinValue, $"{ushort.MinValue}".ParseUShortOrNull());
        }

        [Fact]
        public void ParseUShortOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseUShortOrNull());
            Assert.Null("Z".ParseUShortOrNull(NumberStyles.Integer));
        }
    }
}
