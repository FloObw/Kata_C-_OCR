using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace Kata_OCR.Tests
{
    public class ChecksumTests
    {
        [Theory(Skip = "TODO: Implement a Checksum helper method")]
        [InlineData(123456789, true)]
        [InlineData(382913738, false)]
        public void TestValidChecksum(int number, bool isValid)
        {
            //bool isValidChecksum = Checksum.IsValid(number);
            //Assert.Equal(isValid, isValidChecksum);
        }
    }
}
