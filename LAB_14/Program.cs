using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml.Serialization;

namespace LAB_14
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1

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

            #endregion 1

            #region 2

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

            #endregion 2

            #region 3

            //Person man = new Person("Max", 18);

            //string json = JsonSerializer.Serialize<Person>(man);

            //Console.WriteLine(json);

            //Person manNew = JsonSerializer.Deserialize<Person>(json);
            //Console.WriteLine($"Name: {manNew.Name} Age: {manNew.Age}");

            #endregion 3

            #region 4

            Person man = new Person("Max", 18);

            XmlSerializer formatter = new XmlSerializer(typeof(Person));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"..\..\persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, man);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream fs = new FileStream(@"..\..\persons.xml", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.Name} --- Возраст: {newPerson.Age}");
            }

            #endregion 4

        }
    }
}
