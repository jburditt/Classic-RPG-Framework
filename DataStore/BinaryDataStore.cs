using Common;

namespace DataStore
{
    public class BinaryDataStore : IDataStore
    {
        public string FilePath { get; set; }

        public BinaryDataStore() { }

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
            if (obj == null)
                return;

            Serializer.BinarySerialize(obj, $"{FilePath}{name}.dat");
        }
    }
}