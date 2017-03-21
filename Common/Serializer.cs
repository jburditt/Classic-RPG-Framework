using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Xml;
using System.Xml.Serialization;
//using Newtonsoft.Json;

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

        public static string XmlSerializeToString<T>(T value)
        {
            if (value == null)
                return null;

            var writer = new StringWriter(CultureInfo.InvariantCulture);
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(writer, value);
            return writer.ToString();
        }


        public static T XmlDeserializeToString<T>(string serializedString)
        {
            if (string.IsNullOrEmpty(serializedString))
                return default(T);

            var x = new XmlSerializer(typeof(T));
            var deserializedClass = (T)x.Deserialize(new StringReader(serializedString));

            return deserializedClass;
        }

        //public static string JsonSerialize(this object obj, Formatting formatting = Formatting.None, JsonSerializerSettings serializerSettings = null)
        //{
        //    if (serializerSettings == null)
        //        serializerSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        //    return JsonConvert.SerializeObject(obj, formatting, serializerSettings);
        //}

        //public static T JsonDeserialize<T>(this string str, JsonSerializerSettings serializerSettings = null)
        //{
        //    return JsonConvert.DeserializeObject<T>(str, serializerSettings);
        //}
    }
}