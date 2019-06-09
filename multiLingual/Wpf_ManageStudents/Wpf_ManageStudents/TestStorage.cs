using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Wpf_ManageStudents
{
    internal class TestStorage
    {
        internal static void WriteXml<T>(T data, string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                FileStream stream;
                stream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(stream, data);
                stream.Close();
            }
            catch (Exception x)
            {
                Console.WriteLine(x);
                throw;
            }
        }

        internal static T ReadXml<T>(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x, "Caution...");
                return default(T);
            }
        }
    }
}