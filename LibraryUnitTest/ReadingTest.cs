using Data_Class_Library.Classes;

namespace LibraryUnitTest
{
    [TestClass]
    public class ReadingTest
    {

        readonly Reading readingCorrect = new() { Id = 1, MacAddressSensor = "DADWDA", OpenedBy = 1, Time = DateTime.Now.ToString() };
        readonly Reading readingMacNull = new() { Id = 2, MacAddressSensor = null, OpenedBy = 1, Time = DateTime.Now.ToString() };
        readonly Reading readingMacTooShort = new() { Id = 3, MacAddressSensor = "D", OpenedBy = 1, Time = DateTime.Now.ToString() };
        readonly Reading readingOpenedTooShort = new() { Id = 4, MacAddressSensor = "DADWDA", OpenedBy = -1, Time = DateTime.Now.ToString() };

        [TestMethod]
        public void ValidateMacAddressSensorTest()
        {
            readingCorrect.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => readingMacNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => readingMacTooShort.Validate());
        }

        public void OpenedBy(int openedBy)
        {
            readingCorrect.OpenedBy = openedBy;
            readingCorrect.Validate();
        }

        [TestMethod]
        public void ValidateOpenedByTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => readingOpenedTooShort.Validate());
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
