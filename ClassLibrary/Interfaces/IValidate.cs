using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Class_Library.Interfaces
{
    /// <summary>
    /// Interface for adding a Validate method to a class.
    /// </summary>
    public interface IValidate
    {
        /// <summary>
        /// Validator Method that throws exceptions, if the class is invalid.
        /// </summary>
        void Validate();

    }
}
