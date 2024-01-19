namespace NEALibrarySystem
{
    /// <summary>
    /// Class used to store a value, and a reference to a class. Used to link an attribute to a class
    /// </summary>
    /// <typeparam name="T">Data type of the value being stored</typeparam>
    /// <typeparam name="F">Data type of the class being referenced</typeparam>
    public class ReferenceClass<T, F> where F : class
    {
        public T Value { get; set; }
        public F Reference { get; set; }
    }
}