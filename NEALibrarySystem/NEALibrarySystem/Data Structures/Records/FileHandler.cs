using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem.Data_Structures
{
    /// <summary>
    /// Saves and loads files
    /// </summary>
    public static class FileHandler
    {
        /// <summary>
        /// Saves file
        /// </summary>
        /// <typeparam name="FileType">Type of data structure</typeparam>
        /// <param name="data">Contents of the data structure</param>
        /// <param name="filePath">Path to save the file</param>
        /// <param name="fileName">Name and type of the file</param>
        public static void SaveFile<FileType>(FileType data, string filePath, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath + fileName + ".bin", FileMode.Create);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        /// <summary>
        /// Loads a binary files contents into the specified data structure format
        /// </summary>
        /// <typeparam name="FileType">data structure format of the file</typeparam>
        /// <param name="filePath">Path to load the file from</param>
        /// <param name="fileName">Name and type of the file</param>
        /// <returns>Returns the contents of the file</returns>
        public static FileType LoadFile<FileType>(string filePath, string fileName)
        {
            if (File.Exists(filePath + fileName + ".bin")) 
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(filePath + fileName + ".bin", FileMode.Open);
                FileType data = default(FileType);

                if (stream.Length != 0)
                    data = (FileType)formatter.Deserialize(stream);
                stream.Close();

                return data;
            }
            else 
            {
                MessageBox.Show("File not found");
                return default(FileType);
            }
        }
        /// <summary>
        /// creates the directory to save the data fields to
        /// </summary>
        public static void CreateDataDirectory()
        {
            Directory.CreateDirectory(Application.StartupPath + "\\data");
        }
        public static void SaveBooks() 
        {
            List<string> titles = GetUniqueItems(DataLibrary.Titles);
        }
        private static List<T> GetUniqueItems<T, F>(List<ReferenceClass<T, F>> itemList, SearchAndSort.Compare<ReferenceClass<T, F>, T> compare) where F : class
        {
            List<T> uniqueItems = new List<T>(); 
            foreach (ReferenceClass<T, F> item in itemList)
            {
                if (SearchAndSort.Binary(uniqueItems, item, compare) == -1)
                    SearchAndSort.BinaryReferenceInsert
            }
        }
    }
}
