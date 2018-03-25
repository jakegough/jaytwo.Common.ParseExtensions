using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseFloatExtensionsTests
    {
		[Fact]
		public void ParseFloat_works_with_valid_value()
        {
            Assert.Equal(1.5, "1.5".ParseFloat());
            Assert.Equal(1.5, "1.5".ParseFloat(NumberStyles.AllowDecimalPoint));

            Assert.Equal(0, "0".ParseFloat());
            Assert.Equal(float.MaxValue, " 3.40282347E+38".ParseFloat());
            Assert.Equal(float.MinValue, "-3.40282347E+38".ParseFloat());
        }

        [Fact]
        public void ParseFloat_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseFloat());
        }
        
        [Fact]
        public void ParseFloatOrNull_works_with_valid_value()
        {
            Assert.Equal((float)1.5, "1.5".ParseFloatOrNull());
            Assert.Equal((float)1.5, "1.5".ParseFloatOrNull(NumberStyles.AllowDecimalPoint));

            Assert.Equal(0, "0".ParseFloatOrNull());
            Assert.Equal(float.MaxValue, " 3.40282347E+38".ParseFloatOrNull());
            Assert.Equal(float.MinValue, "-3.40282347E+38".ParseFloatOrNull());
        }

        [Fact]
        public void ParseFloatOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseFloatOrNull());
            Assert.Null("Z".ParseFloatOrNull(NumberStyles.AllowDecimalPoint));
        }
    }
}
