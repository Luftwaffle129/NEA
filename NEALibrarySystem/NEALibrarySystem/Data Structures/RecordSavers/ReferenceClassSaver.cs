using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.RecordSavers
{
    [System.Serializable]
    public class ReferenceClassSaver<T, F> where F : class
    {
        T Value;
        F Reference
            ;
        public ReferenceClassSaver(ReferenceClass<T, F> referenceClass) 
        {
            Value = referenceClass.Value;
            Reference = referenceClass.Reference;
        }
    }
}
