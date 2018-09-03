using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.entities
{
    public class AliveRange
    {
        public int BeginYear { get; internal set; }

        public int EndYear { get; internal set; }

        public List<AliveRange> Children { get; internal set; }

        public List<Person> Persons { get; internal set;}

        public AliveRange()
        {
            Persons = new List<Person>();
            Children = new List<AliveRange>();
            BeginYear = 1900;
            EndYear = 2000;
        }

        public AliveRange(Person p)
        {
            Persons = new List<Person>();
            Children = new List<AliveRange>();
            BeginYear = p.BirthYear;
            EndYear = p.DeathYear;
            Persons.Add(p);
        }

        public bool AddPerson(Person p)
        {
            if ((p.BirthYear >= BeginYear && p.BirthYear <= EndYear) || (p.DeathYear >= BeginYear && p.DeathYear <= EndYear))
            {
                Persons.Add(p);
                UpdateChildren(p);
                return true;
            }
            return false;
        }

        private void UpdateChildren(Person p)
        {
            var compatibleChild = false;
            foreach (AliveRange range in Children)
            {
                compatibleChild = compatibleChild || range.AddPerson(p);
            }

            if (!compatibleChild)
            {
                var child = new AliveRange(p);
                Children.Add(child);
            }
        }
    }
}
