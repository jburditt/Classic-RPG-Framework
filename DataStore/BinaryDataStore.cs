using Common;

namespace DataStore
{
    public class BinaryDataStore : IDataStore
    {
        public string FilePath { get; set; }

        public BinaryDataStore(string filePath)
        {
            FilePath = filePath;
        }

        public T Load<T>(string name)
        {
            return Serializer.BinaryDeserialize<T>($"{FilePath}{name}.dat");
        }

        public void Save<T>(T obj, string name)
        {
            Serializer.BinarySerialize(obj, $"{FilePath}{name}.dat");
        }
    }
}