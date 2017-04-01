using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Common
{
    public static class Serializer
    {
        public static void BinarySerialize(object obj, string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Create))
            {
                var bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, obj);
            }
        }

        public static object BinaryDeserialize(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open))
            {
                var bformatter = new BinaryFormatter();
                return bformatter.Deserialize(stream);
            }
        }

        public static void XmlSerialize<T>(T obj, string filePath)
        {
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

        public static T XmlDeserialize<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                reader?.Close();
            }
        }       
    }
}