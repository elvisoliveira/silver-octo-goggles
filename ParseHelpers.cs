using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp
{
    internal static class ParseHelpers
    {
        private static Stream ToStream(this string @this)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(@this);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static T Deserialize<T>(this string @this) where T : class
        {
            var reader = XmlReader.Create(@this.Trim().ToStream(),
                new XmlReaderSettings()
                {
                    ConformanceLevel = ConformanceLevel.Document
                }
            );
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }

        public static string Serialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(writer, value);
                return stringWriter.ToString();
            }
        }
    }
}