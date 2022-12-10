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

        #region Internal Classes
        internal class Test1Manager : GenericManager<Key>
        {

            #region Static Fields
            /// <summary>
            /// A static dictionary, is used such that all values of the manager, is consistent across instances.
            /// </summary>
            private static Dictionary<int, Key> _keysDictionary = new Dictionary<int, Key>();
            /// <summary>
            /// A static id-counter, is used such that the next ids of the manager, is consistent across instances.
            /// </summary>
            private static int _nextId = 1;
            #endregion

            #region Properties
            public override Dictionary<int, Key> Values { get { return _keysDictionary; } set { _keysDictionary = value; } }
            public override int NextIdentity { get { return _nextId; } set { _nextId = value; } }
            #endregion

            #region Constructor
            /// <summary>
            /// Default Constructor with no custom behaviour.
            /// </summary>
            public Test1Manager()
            {

            }
            #endregion

            #region Methods

            #endregion


        }
        internal class Test2Manager : GenericManager<Key>
        {

            #region Static Fields
            /// <summary>
            /// A static dictionary, is used such that all values of the manager, is consistent across instances.
            /// </summary>
            private static Dictionary<int, Key> _keysDictionary = new Dictionary<int, Key>();
            /// <summary>
            /// A static id-counter, is used such that the next ids of the manager, is consistent across instances.
            /// </summary>
            private static int _nextId = 1;
            #endregion

            #region Properties
            public override Dictionary<int, Key> Values { get { return _keysDictionary; } set { _keysDictionary = value; } }
            public override int NextIdentity { get { return _nextId; } set { _nextId = value; } }
            #endregion

            #region Constructor
            /// <summary>
            /// Default Constructor with no custom behaviour.
            /// </summary>
            public Test2Manager()
            {

            }
            #endregion

            #region Methods

            #endregion


        }
        #endregion

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

            //Arrange
            int updateKeyId = 1;
            Key preUpdateKey = KeysManager.GetByIdentity(updateKeyId);

            string expectedKeyName = "Morten";
            string expectedKeyEmail = "Morten@gmail.com";
            string expectedKeyPhone = "88888888";

            int exceptionId = 99;

            Key updateKey = new Key() { Id = updateKeyId, Name = expectedKeyName, Email = expectedKeyEmail, Phone = expectedKeyPhone };

            //Act
            Key updatedKey = KeysManager.Update(updateKeyId, updateKey);

            //Assert
            Assert.AreEqual(expectedKeyName, updateKey.Name);
            Assert.AreEqual(expectedKeyEmail, updatedKey.Email);
            Assert.AreEqual(expectedKeyPhone, updatedKey.Phone);
            Assert.AreSame(updateKey, updatedKey);
            Assert.AreNotSame(updatedKey, preUpdateKey);
            Assert.ThrowsException<KeyNotFoundException>(() => KeysManager.Update(exceptionId, updateKey));

        }

        [TestMethod()]
        [DataRow(1, 101)]
        [DataRow(2, 102)]
        [DataRow(3, 103)]
        public void DeleteTest(int expected, int exception)
        {

            //Arrange 
            int expectedId = expected;
            int exceptionId = exception;

            //Act
            Key result = KeysManager.Delete(expected);
            int actualId = result.Id;

            //Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.ThrowsException<KeyNotFoundException>(() => KeysManager.Delete(exceptionId));

        }

        /// <summary>
        /// Test to make check that the static properties of one manager, is not shared across all.
        /// And that the properties of the generic manager, indeed uses the static properties giveen by the derived classes.
        /// </summary>
        [TestMethod()]
        public void StaticPropertiesTest()
        {

            //Arrange
            GenericManager<Key> test1_0Manager = new Test1Manager();
            GenericManager<Key> test1_1Manager;
            GenericManager<Key> test2_0Manager = new Test2Manager();
            GenericManager<Key> test2_1Manager;
            
            //Act
            test1_0Manager.NextIdentity += 100;
            test2_0Manager.NextIdentity += 10;

            test1_1Manager = new Test1Manager();
            test2_1Manager = new Test2Manager();

            //Assert
            //Testing references.
            Assert.AreNotSame(test1_0Manager, test1_1Manager);
            Assert.AreNotSame(test2_0Manager, test2_1Manager);
            //Testing a static property reference.
            Assert.AreEqual(test1_0Manager.NextIdentity, test1_1Manager.NextIdentity);
            Assert.AreEqual(test2_0Manager.NextIdentity, test2_1Manager.NextIdentity);
            //Testing that the values of one, has not affected another.
            Assert.AreNotEqual(test1_0Manager.NextIdentity, test2_0Manager.NextIdentity);
            //Testing that a class initiated after the assignment of the property, has reflected the change.

        }

    }
}