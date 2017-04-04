using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;
using System.Globalization;

namespace Task1.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [TestCase("NRP", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1(425) 555 - 0100")]
        [TestCase("G", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1(425) 555 - 0100")]
        [TestCase("", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1(425) 555 - 0100")]
        [TestCase(null, ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1(425) 555 - 0100")]
        [TestCase("P", ExpectedResult = "Customer record: +1(425) 555 - 0100")]
        [TestCase("NR", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("N", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("R", ExpectedResult = "Customer record: 1000000")]
        public string ToString_WithFormatProvider_PositiveTests(string format)
        {
            Customer person = new Customer("Jeffrey Richter", "+1(425) 555 - 0100", 1000000);
            return person.ToString(format, CultureInfo.InvariantCulture);
        }

        [TestCase("NRP", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1(425) 555 - 0100")]
        [TestCase("G", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1(425) 555 - 0100")]
        [TestCase("", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1(425) 555 - 0100")]
        [TestCase(null, ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1(425) 555 - 0100")]
        [TestCase("P", ExpectedResult = "Customer record: +1(425) 555 - 0100")]
        [TestCase("NR", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("N", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("R", ExpectedResult = "Customer record: 1000000")]
        public string ToString_WithoutFormatProvider_PositiveTests(string format)
        {
            Customer person = new Customer("Jeffrey Richter", "+1(425) 555 - 0100", 1000000);
            return person.ToString(format);
        }

        [TestCase("ND")]
        [TestCase("GC")]
        public void ToString_InvalidFormat_ThrowsFormatException(string format)
        {
            Customer person = new Customer("Jeffrey Richter", "+1(425) 555 - 0100", 1000000);
            Assert.Throws<FormatException>(() => person.ToString(format));
        }
                



        [TestCase("{0:GC}", ExpectedResult = "Customer record: Jeffrey Richter, $1,000,000.00, +1(425) 555 - 0100")]
        [TestCase("{0:NRC}", ExpectedResult = "Customer record: Jeffrey Richter, $1,000,000.00")]
        [TestCase("{0:NUP}", ExpectedResult = "Customer record: JEFFREY RICHTER")]
        [TestCase("{0:RC}", ExpectedResult = "Customer record: $1,000,000.00")]
        
        public string Format_NormalFormatStrings_PositiveTests(string format)
        {
            CustomerFormatter formatter = new CustomerFormatter();
            Customer person = new Customer("Jeffrey Richter", "+1(425) 555 - 0100", 1000000);
            return string.Format(formatter, format, person);
            
        }

        [TestCase("{0:RCM}")]
        public void Format_InvalidFormatStrings_ThrowsFormatException(string format)
        {
            CustomerFormatter formatter = new CustomerFormatter();
            Customer person = new Customer("Jeffrey Richter", "+1(425) 555 - 0100", 1000000);
            Assert.Throws<FormatException>(() => string.Format(formatter, format, person)); 
        }
        
        [TestCase("{0:GC}")]
        [TestCase("{0:NRC}")]
        [TestCase("{0:NUP}")]
        [TestCase("{0:RC}")]
        public void Format_NullReferencedCustomer_ThrowsArgumentNullException(string format)
        {
            CustomerFormatter formatter = new CustomerFormatter();
            Customer person = null;
            Assert.Throws<ArgumentNullException>(() => string.Format(formatter, format, person));
        }
        


        [TestCase("{0:GC}")]
        [TestCase("{0:NRC}")]
        [TestCase("{0:NUP}")]
        [TestCase("{0:RC}")]
        public void Format_ObjectArgumentIsNotCustomer_ThrowsArgumentException(string format)
        {
            CustomerFormatter formatter = new CustomerFormatter();
            Object person = new Object();
            Assert.Throws<ArgumentException>(() => string.Format(formatter, format, person));
        }
        
    }
}
