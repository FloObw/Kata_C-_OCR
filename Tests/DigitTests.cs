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
            int numberAsInt;
            bool isReadable =  digit.TryGetNumber(out numberAsInt);
            string number = numberAsInt.ToString();
            Assert.Equal(expected.ToString(), number);
            Assert.Equal(true, isReadable);
        }

        [Theory]
        [InlineData(new[] { " _ ", "| |", "|_|" }, 0)]
        [InlineData(new[] { "   ", "  |", "  |" }, 1)]
        [InlineData(new[] { " _ ", " _|", "|_ " }, 2)]
        public void TestValidNumber2(string[] input, int expected)
        {
            var digit = BuildDigit(input);
            int number;
            bool isReadable = digit.TryGetNumber(out number);
            Assert.Equal(true, isReadable);
            Assert.Equal(expected, number);
        }

        [Theory]
        [InlineData(new[] { "   ", "   ", "   " }, "-1")]
        [InlineData(new[] { "   ", " _|", "  |" }, "-1")]
        public void TestInvalidNumber(string[] input, string expected)
        {
            var digit = BuildDigit(input);
            int numberAsInt;
            bool isReadable = digit.TryGetNumber(out numberAsInt);
            string number = numberAsInt.ToString();
            Assert.Equal(expected, number);
            Assert.Equal(false, isReadable);
        }

        [Theory]
        [InlineData(new[] { "   ", "   ", "   " }, -1)]
        [InlineData(new[] { "   ", " _|", "  |" }, -1)]
        public void TestInvalidNumber2(string[] input, int expected)
        {
            var digit = BuildDigit(input);
            int number;
            bool isReadable = digit.TryGetNumber(out number);
            Assert.Equal(false, isReadable);
            Assert.Equal(expected, number);
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
