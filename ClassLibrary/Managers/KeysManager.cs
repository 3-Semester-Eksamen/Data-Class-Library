using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Class_Library.Classes;

namespace Data_Class_Library.Managers
{
    public class KeysManager : GenericManager<Key>
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
        public KeysManager()
        {

        }
        #endregion

        #region Methods

        #endregion


    }
}
