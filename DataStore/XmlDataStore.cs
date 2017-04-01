using System.IO;
using System.Xml.Serialization;

namespace DataStore
{
    public class XmlDataStore : IDataStore
    {
        private string FilePath { get; set; }

        public XmlDataStore(string filePath = "../../../Data/")
        {
            FilePath = filePath;
        }

        public T Load<T>(string name)
        {
            StreamReader reader = null;

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader($"{FilePath}{name}.xml");
                var obj = (T)serializer.Deserialize(reader);
                return obj;
            } finally
            {
                reader?.Close();
            }
        }

        public void Save<T>(T obj, string name)
        {
            TextWriter writer = null;

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter($"{FilePath}{name}.xml", false);
                serializer.Serialize(writer, obj);
            }
            finally
            {
                writer?.Close();
            }
        }
    }
}