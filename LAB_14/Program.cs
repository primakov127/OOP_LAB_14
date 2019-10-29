using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace LAB_14
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.1

            //Person man = new Person("Max", 18);

            //BinaryFormatter formatter = new BinaryFormatter();
            //using (FileStream fs = new FileStream(@"..\..\person.dat", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, man);
            //}

            //using (FileStream fs = new FileStream(@"..\..\person.dat", FileMode.OpenOrCreate))
            //{
            //    Person manNew = (Person)formatter.Deserialize(fs);

            //    Console.WriteLine($"Name: {manNew.Name} Age: {manNew.Age}");
            //}

            #endregion 1.1

            #region 1.2

            //Person man = new Person("Max", 18);

            //SoapFormatter formatter = new SoapFormatter();

            //using (FileStream fs = new FileStream(@"..\..\person.soap", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, man);
            //}

            //using (FileStream fs = new FileStream(@"..\..\person.soap", FileMode.OpenOrCreate))
            //{
            //    Person manNew = (Person)formatter.Deserialize(fs);

            //    Console.WriteLine($"Name: {manNew.Name} Age: {manNew.Age}");
            //}

            #endregion 1.2

            #region 1.3

            //Person man = new Person("Max", 18);

            //string json = JsonSerializer.Serialize<Person>(man);

            //Console.WriteLine(json);

            //Person manNew = JsonSerializer.Deserialize<Person>(json);
            //Console.WriteLine($"Name: {manNew.Name} Age: {manNew.Age}");

            #endregion 1.3

            #region 1.4

            //Person man = new Person("Max", 18);

            //XmlSerializer formatter = new XmlSerializer(typeof(Person));

            //// получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream(@"..\..\persons.xml", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, man);

            //    Console.WriteLine("Объект сериализован");
            //}

            //// десериализация
            //using (FileStream fs = new FileStream(@"..\..\persons.xml", FileMode.OpenOrCreate))
            //{
            //    Person newPerson = (Person)formatter.Deserialize(fs);

            //    Console.WriteLine("Объект десериализован");
            //    Console.WriteLine($"Имя: {newPerson.Name} --- Возраст: {newPerson.Age}");
            //}

            #endregion 1.4

            #region 2.1

            //Person man1 = new Person("Max", 18);
            //Person man2 = new Person("Pasha", 19);
            //Person[] mans = new Person[] { man1, man2 };
            //BinaryFormatter formatter = new BinaryFormatter();
            //using (FileStream fs = new FileStream(@"..\..\person.dat", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, mans);
            //}

            //using (FileStream fs = new FileStream(@"..\..\person.dat", FileMode.OpenOrCreate))
            //{
            //    Person[] mansNew = (Person[])formatter.Deserialize(fs);

            //    foreach (var man in mansNew)
            //        Console.WriteLine($"Name: {man.Name} Age: {man.Age}");

            //}

            #endregion 2.1

            #region 3.1

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"..\..\persons.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            XmlNode childnode = xRoot.SelectSingleNode("//Person/Name");
            if (childnode != null)
                Console.WriteLine(childnode.OuterXml);

            #endregion 3.1

            #region 4.1

            XDocument xDocument = new XDocument();
            XElement man1 = new XElement("Name");
            XAttribute man1_name = new XAttribute("Name", "Leha");
            XElement age1 = new XElement("Age", "21");
            XElement money1 = new XElement("Money", "600");
            man1.Add(man1_name);
            man1.Add(age1);
            man1.Add(money1);

            XElement man2 = new XElement("Name");
            XAttribute man2_name = new XAttribute("Name", "Serega");
            XElement age2 = new XElement("Age", "22");
            XElement money2 = new XElement("Money", "1000");
            man2.Add(man2_name);
            man2.Add(age2);
            man2.Add(money2);

            XElement man3 = new XElement("Name");
            XAttribute man3_name = new XAttribute("Name", "Sanya");
            XElement age3 = new XElement("Age", "20");
            XElement money3 = new XElement("Money", "300");
            man3.Add(man3_name);
            man3.Add(age3);
            man3.Add(money3);

            XElement people = new XElement("people");
            people.Add(man1);
            people.Add(man2);
            people.Add(man3);

            xDocument.Add(people);
            xDocument.Save(@"..\..\Xlinq.xml");


            var byName = from el in xDocument.Element("people").Elements("Name")
                        where (el.Attribute("Name").Value).StartsWith("S")
                        select new Person
                        {
                            Name = el.Attribute("Name").Value,
                            Age = Convert.ToInt32(el.Element("Age").Value)
                        };
            Console.WriteLine("Peoples(Name start with 'S'): ");
            foreach (var item in byName)
                Console.WriteLine($"Name: {item.Name}| Age: {item.Age}");


            var byAge = from el in xDocument.Element("people").Elements("Name")
                         where Convert.ToInt32(el.Element("Age").Value) >= 21
                         select new Person
                         {
                             Name = el.Attribute("Name").Value,
                             Age = Convert.ToInt32(el.Element("Age").Value)
                         };
            Console.WriteLine("Peoples(Age >= 21): ");
            foreach (var item in byAge)
                Console.WriteLine($"Name: {item.Name}| Age: {item.Age}");

            #endregion 4.1
        }
    }
}
