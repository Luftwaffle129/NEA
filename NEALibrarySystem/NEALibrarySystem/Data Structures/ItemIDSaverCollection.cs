using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures
{
    [System.Serializable]
    public class ItemIDSaverCollection
    {
        public ItemIDSaverCollection(List<ItemID> itemIDs)
        {
            Collection = new ItemIDSaver[itemIDs.Count];
            for (int i = 0; i < itemIDs.Count; i++)
            {
                ItemIDSaver temp = new ItemIDSaver(itemIDs[i]);
                Collection[i] = temp;
            }
        }
        private ItemIDSaver[] collection = new ItemIDSaver[0];
        public ItemIDSaver[] Collection
        {
            get { return collection; }
            set { collection = value ?? new ItemIDSaver[0]; }
        }
    }
}
