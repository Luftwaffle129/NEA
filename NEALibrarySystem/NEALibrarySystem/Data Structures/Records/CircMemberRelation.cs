namespace NEALibrarySystem.Data_Structures.Records
{
    /// <summary>
    /// Used to store the relation between a circulated copy and the book being circulated
    /// </summary>
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
