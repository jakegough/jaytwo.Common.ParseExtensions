using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseDecimalExtensionsTests
    {
		[Fact]
		public void ParseDeciamal_works_with_valid_value()
        {
            Assert.Equal(1.5m, "1.5".ParseDeciamal());
            Assert.Equal(1.5m, "1.5".ParseDeciamal(NumberStyles.AllowDecimalPoint));

            Assert.Equal(0, "0".ParseDeciamal());
            Assert.Equal(decimal.MaxValue, $"{decimal.MaxValue}".ParseDeciamal());
            Assert.Equal(decimal.MinValue, $"{decimal.MinValue}".ParseDeciamal());
        }

        [Fact]
        public void ParseDeciamal_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseDeciamal());
        }
        
        [Fact]
        public void ParseDeciamalOrNull_works_with_valid_value()
        {
            Assert.Equal(1.5m, "1.5".ParseDeciamalOrNull());
            Assert.Equal(1.5m, "1.5".ParseDeciamalOrNull(NumberStyles.AllowDecimalPoint));

            Assert.Equal(0, "0".ParseDeciamalOrNull());
            Assert.Equal(decimal.MaxValue, $"{decimal.MaxValue}".ParseDeciamalOrNull());
            Assert.Equal(decimal.MinValue, $"{decimal.MinValue}".ParseDeciamalOrNull());
        }

        [Fact]
        public void ParseDeciamalOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseDeciamalOrNull());
            Assert.Null("Z".ParseDeciamalOrNull(NumberStyles.AllowDecimalPoint));
        }
    }
}
