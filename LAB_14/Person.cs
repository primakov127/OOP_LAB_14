using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_14
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Name = "Nope";
            Age = 0;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
