using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Class_Library.Interfaces
{
    /// <summary>
    /// Interface for adding an Identity for a class.
    /// </summary>
    public interface IIdentity
    {
        /// <summary>
        /// Id for class.
        /// </summary>
        int? Id { get; set; }
    }
}
