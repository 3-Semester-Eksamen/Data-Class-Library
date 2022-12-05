using Data_Class_Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data_Class_Library.Classes
{
    public class Reading : IIdentity, IValidate
    {

        #region Properties
        /// <summary>
        /// Id of the Reading.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// MacAddress of the Sensor of the Reading.
        /// </summary>
        public string? MacAddressSensor { get; set; }
        /// <summary>
        /// OpenedBy of the Reading.
        /// </summary>
        public int? OpenedBy { get; set; }
        /// <summary>
        /// TimeOpened of the Reading.
        /// </summary>
        public string? Time { get; set; }
        #endregion

        #region Constructor
        public Reading()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Validate Method that calls the individual Validator Methods.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Validate()
        {
            ValidateMacAddressSensor();
            ValidateOpenedBy();
        }
        #region Validator Methods
        /// <summary>
        /// Method that validates the MacAddress.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateMacAddressSensor()
        {

            if (string.IsNullOrWhiteSpace(MacAddressSensor)) throw new ArgumentNullException("MacAddress cannot be null or empty.");
            if (MacAddressSensor.Length < 3) throw new ArgumentOutOfRangeException("MacAddress has to be atleast 4 characters.");
        }
        /// <summary>
        /// Method that validates the OpenedBy
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateOpenedBy()
        {
            if (OpenedBy == null) throw new ArgumentNullException("OpenedBy cannot be null.");
            if (OpenedBy < 0) throw new ArgumentOutOfRangeException("OpenedBy has to be atleast 1.");
        }
        #endregion
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id}, {nameof(MacAddressSensor)}={MacAddressSensor}, {nameof(OpenedBy)}={OpenedBy}, {nameof(Time)}={Time}}}";
        }
        #endregion

 
    }
}
