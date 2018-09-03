using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.entities
{
    public class Person
    {
        public string Name { get; }
        public int BirthYear { get; }
        public int DeathYear { get; }

        public Person(string name, int birth, int death)
        {
            Name = name;
            BirthYear = birth;
            DeathYear = death;
        }

        public override string ToString()
        {
            return Name + " -> " + BirthYear + " - " + DeathYear;
        }
    }
}
