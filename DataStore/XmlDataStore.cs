using Common;

namespace DataStore
{
    public class XmlDataStore : IDataStore
    {
        public string FilePath { get; set; }

        public XmlDataStore(string filePath)
        {
            FilePath = filePath;
        }

        public T Load<T>(string name)
        {
            return Serializer.XmlDeserialize<T>($"{FilePath}{name}.xml");
        }

        public void Save<T>(T obj, string name)
        {
            Serializer.XmlSerialize(obj, $"{FilePath}{name}.xml");
        }
    }
}