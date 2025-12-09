using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using pr8;

namespace pr8
{
    internal class Student : Person
    {

        private string formEducation;
        private int studentGroup;
        private ArrayList test;
        private ArrayList exam;

        public int StudentGroup
        {
            get => studentGroup;
            set
            {
                if (599 >= value && 100 <= value)
                {
                    throw new ArgumentOutOfRangeException("Student group must be in diapazone 100-599");
                }
                else
                {
                    studentGroup = value;
                }
            }
        }

        public Person Person
        {
            get => this;
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value is Student s)
                {
                    firstName = s.firstName;
                    lastName = s.lastName;
                    dateOfBirth = s.dateOfBirth;
                }
                else
                {
                    throw new InvalidOperationException("Cannot set base fields from a non-Student Person instance.");
                }
            }
        }

        public Student
            (string firstName, string lastName,
            DateTime dateOfBirth, string formEducation,
            int studentGroup, ArrayList test, ArrayList exam)
            : base(firstName, lastName, dateOfBirth)
        {
            this.formEducation = formEducation;
            this.studentGroup = studentGroup;
            this.test = new ArrayList(test);
            this.exam = new ArrayList(exam);
        }

        public override object DeepCopy()
        {
            return new Student(firstName, lastName, dateOfBirth,
                formEducation, studentGroup,
                new ArrayList(test), new ArrayList(exam));
        }
        


    }
}
