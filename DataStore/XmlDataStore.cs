using Common;

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
            return Serializer.XmlDeserialize<T>($"{FilePath}{name}.xml");
        }

        public void Save<T>(T obj, string name)
        {
            Serializer.XmlSerialize(obj, $"{FilePath}{name}.xml");
        }
    }
}