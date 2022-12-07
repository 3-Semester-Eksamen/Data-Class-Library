using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Class_Library.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Class_Library.Classes;
using System.Globalization;

namespace Data_Class_Library.Managers.Tests
{
    [TestClass()]
    public class GenericManagerTests
    {

        #region Properties
        public static KeysManager KeysManager = new();
        public static Key ValidKey => new Key() { Id = 1, Email = "ValidEmail", Name = "ValidName", Phone = "ValidPhone" };
        public static Key InvalidKeyNullException = new Key() { Id = 1, Email = "", Name = "", Phone = "" };
        public static Key ÍnvalidKeyOutOfRangeException = new Key() { Id = 1, Email = "1", Name = "1", Phone = "1" };
        #endregion

        #region Initialize Methods
        [TestInitialize]
        public void TestInitialize()
        {
            Dictionary<int, Key> keys = new Dictionary<int, Key>()
            {
                { 1, new Key() { Id = 1, Name = "Key0", Email = "Email0", Phone = "Phone0" } },
                { 2, new Key() { Id = 2, Name = "Key1", Email = "Email1", Phone = "Phone1" } },
                { 3, new Key() { Id = 3, Name = "Key2", Email = "Email2", Phone = "Phone2" } },
                { 4, new Key() { Id = 4, Name = "Key3", Email = "Email3", Phone = "Phone3" } },
                { 5, new Key() { Id = 5, Name = "Key4", Email = "Email4", Phone = "Phone4" } }
            };
            KeysManager = new KeysManager();
            
            KeysManager.Values = keys;
            KeysManager.NextIdentity += keys.Count;

        }
        [TestCleanup]
        public void TestCleanup()
        {

        }
        #endregion


        [TestMethod()]
        public void GetTest()
        {

            //Arrange
            Type expectedType = typeof(List<Key>);

            //Act
            var list = KeysManager.Get();
            var actualType = list.GetType();

            //Assert
            Assert.AreEqual(expectedType, actualType);
            Assert.IsNotNull(list);

        }

        [TestMethod()]
        [DataRow(1, 101)]
        [DataRow(2, 102)]
        [DataRow(3, 103)]
        public void GetByIdentityTest(int expected, int exception)
        {

            //Arrange 
            int expectedId = expected;
            int exceptionId = exception;

            //Act
            Key result = KeysManager.GetByIdentity(expected);
            int actualId = result.Id;

            //Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.ThrowsException<KeyNotFoundException>(() => KeysManager.GetByIdentity(exceptionId));

        }

        [TestMethod()]
        public void AddTest()
        {

            //Arrange
            Key key = ValidKey;
            Key nullKey = InvalidKeyNullException;
            Key oorKey = ÍnvalidKeyOutOfRangeException;

            int expectedId = KeysManager.NextIdentity;
            int initialLength = KeysManager.Get().Count;

            //Act
            Key result = KeysManager.Add(key);
            int actualId = result.Id;
            int actualLength = KeysManager.Get().Count;

            //Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.AreNotEqual(initialLength, actualLength);
            Assert.ThrowsException<ArgumentNullException>(() => KeysManager.Add(nullKey));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => KeysManager.Add(oorKey));

        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}