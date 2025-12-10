using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr8
{
    internal class Person
    {
        protected string firstName;
        protected string lastName;
        protected DateTime dateOfBirth;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }

        public Person() { }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }

        public virtual object DeepCopy()
        {
            return new Person(firstName, lastName, dateOfBirth);
        }

        public override bool Equals(object obj)
        { 
            if (obj is Person other)
            {
                return firstName == other.firstName &&
                       lastName == other.lastName &&
                       dateOfBirth == other.dateOfBirth;
            }
            return false;
        }

        public static bool operator ==(Person p1, Person p2) 
        { 
            return p1.Equals(p2);
        } 
        public static bool operator !=(Person p1, Person p2) 
        { 
            return !(p1==p2);
        }

        public override int GetHashCode()
        {
            return (firstName, lastName, dateOfBirth).GetHashCode();
        }

    }
}
