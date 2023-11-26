using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem
{
    public class ReferenceClass<T, F> where F : class
    {
        public T Value { get; set; }
        public F Reference { get; set; }
    }
}