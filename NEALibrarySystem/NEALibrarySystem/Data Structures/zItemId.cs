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
    public class ItemId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        #region Constructors
        public ItemId() { }
        /// <summary>
        /// Constructor for getting records from the binary files
        /// </summary>
        /// <param name="itemIDSaver">record to load</param>
        public ItemId(ItemIDSaver itemIDSaver)
        {
            Id = itemIDSaver.ID;
            Name = itemIDSaver.Name;
        }
        #endregion
    }
}
