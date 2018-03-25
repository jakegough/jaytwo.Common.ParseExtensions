using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseUIntExtensionsTests
    {
		[Fact]
		public void ParseUInt_works_with_valid_value()
        {
            Assert.Equal(1u, "1".ParseUInt());
            Assert.Equal(1u, "1".ParseUInt(NumberStyles.Integer));

            Assert.Equal(0u, "0".ParseUInt());
            Assert.Equal(uint.MaxValue, $"{uint.MaxValue}".ParseUInt());
            Assert.Equal(uint.MinValue, $"{uint.MinValue}".ParseUInt());
        }

        [Fact]
        public void ParseUInt_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseUInt());
        }
        
        [Fact]
        public void ParseUIntOrNull_works_with_valid_value()
        {
            Assert.Equal(1u, "1".ParseUIntOrNull());
            Assert.Equal(1u, "1".ParseUIntOrNull(NumberStyles.Integer));

            Assert.Equal(0u, "0".ParseUIntOrNull());
            Assert.Equal(uint.MaxValue, $"{uint.MaxValue}".ParseUIntOrNull());
            Assert.Equal(uint.MinValue, $"{uint.MinValue}".ParseUIntOrNull());
        }

        [Fact]
        public void ParseUIntOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseUIntOrNull());
            Assert.Null("Z".ParseUIntOrNull(NumberStyles.Integer));
        }
    }
}
