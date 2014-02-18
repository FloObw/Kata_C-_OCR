using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Kata_OCR.Tests
{
    public class FileTests
    {
        [Theory]
        [InlineData("    _  _  _  _  _  _  _  _ ", 27)]
        public void TestValidLineLength(string line, int assumedLength)
        {
            Assert.Equal(assumedLength, line.Length);         
        }

        [Theory]
        [InlineData("     _  _  _  _  _  _  _  _ ", 27)]
        public void TestInvalidLineLength(string line, int assumedLength)
        {
            Assert.NotEqual(assumedLength, line.Length);         
        }


        [Theory]
        [InlineData("    _  _  _  _  _  _  _  _\\ |_||_   ||_ | ||_|| || || |\\  | _|  | _||_||_||_||_||_|", 3)]
        public void TestValidLinesAmount(string line, Boolean expected)
        {
            int numLines = line.Split('\\').Length;
            Assert.Equal(expected, numLines % 3 == 0);
        }

        [Theory]
        [InlineData("    _  _  _  _  _  _  _  _ \\|_||_   ||_ | ||_|| || || |", 3)]
        public void TestInvalidLinesAmount(string line, Boolean expected)
        {
             int numLines = line.Split('\\').Length;
             Assert.NotEqual(expected, numLines % 3 == 0);
        }

    }
}
