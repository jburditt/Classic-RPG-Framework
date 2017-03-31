//using Common;
using System.IO;
using System.Xml.Serialization;

namespace DataStore
{
    public class XmlDataStore : IDataStore
    {
        private const string filePath = "../../../Data/";

        public T Load<T>(string name)
        {
            var serializer = new XmlSerializer(typeof(T));
            var reader = new StreamReader($"{filePath}{name}.xml");
            var obj = (T)serializer.Deserialize(reader);
            return obj;
        }

        public void Save<T>(T obj, string name)
        {
            //Serializer.XmlSerialize(obj, $"../../../Data/{name}.xml");
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, false);
                serializer.Serialize(writer, obj);
            }
            finally
            {
                writer?.Close();
            }
        }
    }
}