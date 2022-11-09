using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;

namespace XmlSerialization {
    class Program {
        static void Main(string[] args) {
            City city = new City() { Name = "Potato Kingdom", Population = 942135 };
            Person person = new Person() { Name = "Potato Guy", Age = 21, City = city};
            DateTime timer;

            // XML Serialization
            timer = DateTime.Now;

            var path = "../../../people.xml";
            var serializer = new XmlSerializer(typeof(Person));

            using (var writer = new StreamWriter(path)) {
                serializer.Serialize(writer, person);
            }

            using (XmlReader reader = XmlReader.Create(path)) {
                Console.WriteLine((Person) serializer.Deserialize(reader));
            }

            Console.WriteLine($"Done in {(DateTime.Now - timer).Milliseconds} milliseconds");

            // JSON Serialization
            Console.WriteLine("\n\n");
            timer = DateTime.Now;


            var JSONSerialized = JsonConvert.SerializeObject(person);

            path = "../../../people.json";
            using (var writer = new StreamWriter(path)) {
                writer.WriteLine(JSONSerialized);
            }

            using (var reader = new StreamReader(path)) {
                Console.WriteLine(JsonConvert.DeserializeObject(reader.ReadToEnd()));
            }

            Console.WriteLine($"Done in {(DateTime.Now - timer).Milliseconds} milliseconds");
        }
    }
}
