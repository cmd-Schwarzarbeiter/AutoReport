using System;
using System.IO;
using System.Xml.Serialization;

namespace AutoReport
{
    public static class XmlHelper
    {
        // Method to deserialize a ServerCollection from XML
        public static ServerCollection DeserializeServerFromXml(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ServerCollection));
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    return (ServerCollection)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deserializing ServerCollection: {ex.Message}", ex);
            }
        }

        // Method to serialize a ServerCollection to XML
        public static void SerializeServerToXml(string filePath, ServerCollection serverCollection)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ServerCollection));
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, serverCollection);
                }
                Console.WriteLine($"ServerCollection has been saved to '{filePath}'.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error serializing ServerCollection: {ex.Message}", ex);
            }
        }

        // Method to deserialize a Programmverzeichnis from XML
        public static Programmverzeichnis DeserializeProgrammFromXml(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Programmverzeichnis));
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    return (Programmverzeichnis)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deserializing Programmverzeichnis: {ex.Message}", ex);
            }
        }

        // Method to serialize a Programmverzeichnis to XML
        public static void SerializeProgrammToXml(string filePath, Programmverzeichnis programmverzeichnis)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Programmverzeichnis));
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, programmverzeichnis);
                }
                Console.WriteLine($"Programmverzeichnis has been saved to '{filePath}'.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error serializing Programmverzeichnis: {ex.Message}", ex);
            }
        }
    }
}
