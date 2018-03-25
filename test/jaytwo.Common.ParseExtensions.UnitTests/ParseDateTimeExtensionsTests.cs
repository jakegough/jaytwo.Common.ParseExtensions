using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseDateTimeExtensionsTests
    {
        [Fact]
        public void ParseDateTime_works_with_valid_value()
        {
            Assert.Equal(new DateTime(1999, 6, 1), "6/1/1999".ParseDateTime());
            Assert.Equal(new DateTime(1999, 6, 1), "06/01/1999".ParseDateTime());
            Assert.Equal(new DateTime(1999, 6, 1), "1999-06-01".ParseDateTime());

            Assert.Equal(new DateTime(1999, 1, 6), "6/1/1999".ParseDateTime(new CultureInfo("en-GB")));

            Assert.Equal(new DateTime(1999, 1, 6), "6/1/1999".ParseDateTime(new CultureInfo("en-GB"), DateTimeStyles.None));

            Assert.Equal(new DateTime(1999, 6, 1), "6/1/1999".ParseDateTime(DateTimeStyles.None));
        }

        [Fact]
        public void ParseDateTime_fails_with_invalid_value()
        {
            Assert.Throws<FormatException>(() => "Z".ParseDateTime());

            Assert.Throws<FormatException>(() => "Z".ParseDateTime(new CultureInfo("en-GB")));

            Assert.Throws<FormatException>(() => "Z".ParseDateTime(new CultureInfo("en-GB"), DateTimeStyles.None));

            Assert.Throws<FormatException>(() => "Z".ParseDateTime(DateTimeStyles.None));
        }
        
        [Fact]
        public void ParseDateTimeOrNull_works_with_valid_value()
        {
            Assert.Equal(new DateTime(1999, 6, 1), "6/1/1999".ParseDateTimeOrNull());
            Assert.Equal(new DateTime(1999, 6, 1), "06/01/1999".ParseDateTimeOrNull());
            Assert.Equal(new DateTime(1999, 6, 1), "1999-06-01".ParseDateTimeOrNull());

            Assert.Equal(new DateTime(1999, 1, 6), "6/1/1999".ParseDateTimeOrNull(new CultureInfo("en-GB")));

            Assert.Equal(new DateTime(1999, 1, 6), "6/1/1999".ParseDateTimeOrNull(new CultureInfo("en-GB"), DateTimeStyles.None));

            Assert.Equal(new DateTime(1999, 6, 1), "6/1/1999".ParseDateTimeOrNull(DateTimeStyles.None));
        }

        [Fact]
        public void ParseDateTimeOrNull_returns_null_for_invalid_value()
        {
            Assert.Null("Z".ParseDateTimeOrNull());

            Assert.Null("Z".ParseDateTimeOrNull(new CultureInfo("en-GB")));

            Assert.Null("Z".ParseDateTimeOrNull(new CultureInfo("en-GB"), DateTimeStyles.None));

            Assert.Null("Z".ParseDateTimeOrNull(DateTimeStyles.None));
        }
    }
}
