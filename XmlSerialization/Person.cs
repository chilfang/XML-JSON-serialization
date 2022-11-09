using System;
using System.Collections.Generic;
using System.Text;

namespace XmlSerialization {
    public class Person {
        public string Name { get; set; }
        public int Age { get; set; }
        public City City { get; set; }


        public override string ToString() {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("City: " + City.Name);

            return base.ToString();
        }
    }
}
