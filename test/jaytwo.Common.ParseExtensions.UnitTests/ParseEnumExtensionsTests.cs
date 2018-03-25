using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using jaytwo.Common.ParseExtensions;
using System.Globalization;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseEnumExtensionsTests
    {
        [Fact]
        public void ParseEnum_works_with_valid_value()
        {
            Assert.Equal(NumberStyles.Number, "Number".ParseEnum<NumberStyles>());
        }

        [Fact]
        public void ParseEnum_fails_with_invalid_value()
        {
            Assert.Throws<ArgumentException>(() => "Z".ParseEnum<NumberStyles>());
        }
        
        [Fact]
        public void ParseEnumOrNull_works_with_valid_value()
        {
            Assert.Equal(NumberStyles.Number, "Number".ParseEnumOrNull<NumberStyles>());
        }

        [Fact]
        public void ParseEnumOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Foo".ParseEnumOrNull<NumberStyles>());
        }
    }
}
