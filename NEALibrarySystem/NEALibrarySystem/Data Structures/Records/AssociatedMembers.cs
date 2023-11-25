using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    public class AssociatedMembers
    {
        private Member[] _members = new Member[2];
        public Member[] Members 
        { 
            get { return _members; }
            set { _members = value ?? new Member[2]; }
        }
    }
}
