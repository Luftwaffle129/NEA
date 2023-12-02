using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEALibrarySystem.Data_Structures.Records
{
    public class CircMemberRelation
    {
        public Member Member { get; set; }
        public CirculationCopy CirculationCopy { get; set; }
        public CircMemberRelation(Member member, CirculationCopy circulationCopy) 
        { 
            Member = member;
            CirculationCopy = circulationCopy;
        }
    }
}
