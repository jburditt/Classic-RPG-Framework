using Common;
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

        public T Load<T>(string name) where T : new()
        {
            return Serializer.XmlDeserialize<T>($"{name}.xml");
        }

        public void Save<T>(T obj, string name)
        {
            Serializer.XmlSerialize(obj, $"{name}.xml");
        }
    }
}