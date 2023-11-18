using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Item containing a integer ID and a string name
    /// </summary>
    public class ItemID
    {
        public int ID { get; set; }
        public string Name { get; set; }

        #region Constructors
        public ItemID() { }
        /// <summary>
        /// Constructor for getting records from the binary files
        /// </summary>
        /// <param name="itemIDSaver">record to load</param>
        public ItemID(ItemIDSaver itemIDSaver)
        {
            ID = itemIDSaver.ID;
            Name = itemIDSaver.Name;
        }
        #endregion
    }
}
