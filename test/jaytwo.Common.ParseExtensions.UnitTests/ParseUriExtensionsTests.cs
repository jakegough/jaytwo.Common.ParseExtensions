using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace jaytwo.Common.ParseExtensions.UnitTests
{
    public class ParseUriExtensionsTests
    {
        [Fact]
        public void ParseUri_works_for_absolute_uri()
        {
            // arrange
            var url = "http://www.google.com/";

            // act
            var uri = url.ParseUri();

            // assert
            Assert.True(uri.IsAbsoluteUri);
            Assert.Equal(url, uri.AbsoluteUri);
        }

        [Fact]
        public void ParseUri_works_for_relative_path()
        {
            // arrange
            var url = "../images/foo";

            // act
            var uri = url.ParseUri(UriKind.Relative);

            // assert
            Assert.Equal(url, uri.ToString());
        }

        [Fact]
        public void ParseUri_throws_exception_for_uri()
        {
            // arrange
            var url = "foo";

            // act & assert
            Assert.Throws<UriFormatException>(() => url.ParseUri());
        }

        [Fact]
        public void ParseUri_throws_exception_for_bad_relative_uri()
        {
            // arrange
            var url = "http://www.google.com/";

            // act & assert
            Assert.Throws<UriFormatException>(() => url.ParseUri(UriKind.Relative));
        }

        [Fact]
        public void ParseUriOrNull_returns_null_works_for_bad_uri()
        {
            // arrange
            var url = "foo";

            // act
            var uri = url.ParseUriOrNull();

            // assert
            Assert.Null(uri);
        }

        [Fact]
        public void ParseUriOrNull_returns_null_works_for_bad_relative_uri()
        {
            // arrange
            var url = "http://www.google.com/";

            // act
            var uri = url.ParseUriOrNull(UriKind.Relative);

            // assert
            Assert.Null(uri);
        }
    }
}
