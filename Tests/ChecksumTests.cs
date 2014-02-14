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
        [Theory]
        [InlineData(457508000, true)]
        [InlineData(382913738, false)]
        public void TestValidChecksum(int number, bool isValid)
        {            
       
            AccountNumber accNumber = new AccountNumber();
            accNumber.checkIsValidChecksum(number.ToString());
            Boolean validation = accNumber.getIsValidChecksum();
            Assert.Equal(isValid, validation);

        }
        
        [Theory]
        [InlineData(382913738, true)]
        [InlineData(457508000, false)]
        public void TestInvalidChecksum(int number, bool isValid)
        {

            AccountNumber accNumber = new AccountNumber();
            accNumber.checkIsValidChecksum(number.ToString());
            Boolean validation = accNumber.getIsValidChecksum();
            Assert.NotEqual(isValid, validation);

        }

    }
}
