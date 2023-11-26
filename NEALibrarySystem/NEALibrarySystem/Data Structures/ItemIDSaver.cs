using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    [System.Serializable]
    public class ItemIDSaver
    {
        public ItemIDSaver(ItemBook itemID) 
        {
            Id = itemID.Id;
            Name = itemID.Name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
