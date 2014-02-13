using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Kata_OCR.Tests
{
    public class DigitTests
    {
        [Theory]
        [InlineData(new[] { " _ ", "| |", "|_|" }, 0)]
        [InlineData(new[] { "   ", "  |", "  |" }, 1)]
        [InlineData(new[] { " _ ", " _|", "|_ " }, 2)]
        public void TestValidNumber(string[] input, int expected)
        {
            var digit = BuildDigit(input);
            string number = digit.getAsNumber();
            Assert.Equal(expected.ToString(), number);
            bool isReadable = digit.getReadableState();
            Assert.Equal(true, isReadable);
        }

        [Theory]
        [InlineData(new[] { "   ", "   ", "   " }, "?")]
        [InlineData(new[] { "   ", " _|", "  |" }, "?")]
        public void TestInvalidNumber(string[] input, string expected)
        {
            var digit = BuildDigit(input);
            string number = digit.getAsNumber();
            Assert.Equal(expected, number);
            bool isReadable = digit.getReadableState();
            Assert.Equal(false, isReadable);
        }

        private static Digit BuildDigit(string[] input)
        {
            var digit = new Digit();
            for (int i = 0; i < 3; i++)
                digit.addString(i, input[i]);
            return digit;
        }
    }
}
