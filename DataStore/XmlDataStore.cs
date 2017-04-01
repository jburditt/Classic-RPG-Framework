using System.IO;
using System.Xml.Serialization;

namespace DataStore
{
    public class XmlDataStore : IDataStore
    {
        private const string filePath = "../../../Data/";

        public T Load<T>(string name)
        {
            StreamReader reader = null;

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader($"{filePath}{name}.xml");
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
                writer = new StreamWriter($"{filePath}{name}.xml", false);
                serializer.Serialize(writer, obj);
            }
            finally
            {
                writer?.Close();
            }
        }
    }
}