using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR1_2;

namespace PR1_2
{
    internal class Person: IDateAndCopy
    {

        protected string firstName;
        protected string lastName;
        protected DateTime dateOfBirth;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime Date { get => dateOfBirth; set => dateOfBirth = value; }

        public int ChangeYearOfBirth
        {
            get => (int)dateOfBirth.Year;
            set => dateOfBirth = new DateTime(value, dateOfBirth.Month, dateOfBirth.Day);
        }

        public Person(string fisrt_name, string last_name, DateTime dateOfBirth)
        {
            FirstName = fisrt_name;
            LastName = last_name;
            Date = dateOfBirth;
        }
        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            Date = DateTime.MinValue;
        }
        public virtual object DeepCopy()
        {
            return new Person(FirstName, LastName, Date);
        }   

        public override string ToString()
        {
            return $"First name: {FirstName}, Last name:{LastName}, Date of Birth: {Date.ToShortDateString()}";
        }

        public virtual string ToShortString()
        {
            return $"First name: {FirstName}, Last name:{LastName}";
        }

        public virtual bool Equals(Person other)
        {
            if (other == null)
                return false;
            return FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   Date == other.Date;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1, p2))
                return true;
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
                return false;
            return p1.Equals(p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public virtual int GetHashCode()
        {
            return (FirstName, LastName, Date).GetHashCode();
        }
    }
}
