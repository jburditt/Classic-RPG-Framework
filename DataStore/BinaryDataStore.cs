using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    using Common;
    using System.IO;
    using System.Xml.Serialization;

    namespace DataStore
    {
        public class BinaryDataStore : IDataStore
        {
            private string FilePath { get; set; }

            public BinaryDataStore(string filePath = "../../../Data/")
            {
                FilePath = filePath;
            }

            public T Load<T>(string name) where T : new()
            {
                return (T)Serializer.BinaryDeserialize($"{name}.dat");
            }

            public void Save<T>(T obj, string name)
            {
                Serializer.BinarySerialize(obj, $"{name}.dat");
            }
        }
    }
}
