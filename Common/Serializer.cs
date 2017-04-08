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
            if (!File.Exists(filePath))
                return null;

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

        public static T XmlDeserialize<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return default(T);

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

        //[XmlIgnore]
        //public int[,] Readings { get; set; }
        //[XmlArray("Readings")]
        //public int[] ReadingsDto
        //{
        //    get { return Flatten(Readings); }
        //    set { Readings = Expand(value, 4); }
        //}

        public static T[] Flatten<T>(T[,] arr)
        {
            int rows0 = arr.GetLength(0);
            int rows1 = arr.GetLength(1);
            T[] arrFlattened = new T[rows0 * rows1];
            for (int j = 0; j < rows1; j++)
            {
                for (int i = 0; i < rows0; i++)
                {
                    var test = arr[i, j];
                    arrFlattened[i + j * rows0] = arr[i, j];
                }
            }
            return arrFlattened;
        }

        public static T[,] Expand<T>(T[] arr, int rows0)
        {
            int length = arr.GetLength(0);
            int rows1 = length / rows0;
            T[,] arrExpanded = new T[rows0, rows1];
            for (int j = 0; j < rows1; j++)
            {
                for (int i = 0; i < rows0; i++)
                {
                    arrExpanded[i, j] = arr[i + j * rows0];
                }
            }
            return arrExpanded;
        }
    }
}