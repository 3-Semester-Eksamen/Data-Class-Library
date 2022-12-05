using Eksamen_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUnitTest
{
    [TestClass]
    public class ReadingTest
    {
        Reading readingCorrect = new Reading { Id = 1, MacAddressSensor = "DADWDA", OpenedBy = 1, Time = DateTime.Now.ToString() };
        Reading readingMacNull = new Reading { Id = 2, MacAddressSensor = null, OpenedBy = 1, Time = DateTime.Now.ToString() };
        Reading readingMacTooShort = new Reading { Id = 3, MacAddressSensor = "D", OpenedBy = 1, Time = DateTime.Now.ToString() };
        Reading readingOpenedTooShort = new Reading { Id = 5, MacAddressSensor = "DADWDA", OpenedBy = -1, Time = DateTime.Now.ToString() };

        [TestMethod]
        public void ValidateMacAddressSensorTest()
        {
            readingCorrect.ValidateMacAddressSensor();
            Assert.ThrowsException<ArgumentNullException>(() => readingMacNull.ValidateMacAddressSensor());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => readingMacTooShort.ValidateMacAddressSensor());
        }

        public void OpenedBy(int openedBy)
        {
            readingCorrect.OpenedBy = openedBy;
            readingCorrect.ValidateOpenedBy();
        }

        [TestMethod]
        public void ValidateOpenedByTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => readingOpenedTooShort.ValidateOpenedBy());
        }

        [TestMethod]
        public void ValidateTest()
        {
            readingCorrect.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => readingMacNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => readingMacTooShort.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => readingOpenedTooShort.Validate());
        }

        [TestMethod]
        public void ToStringTest()
        {
            readingCorrect.Time = "04/12/2022 16.00.00";
            string str = readingCorrect.ToString();
            Assert.AreEqual("{Id=1, MacAddressSensor=DADWDA, OpenedBy=1, Time=04/12/2022 16.00.00}", str);
        }
    }
}
