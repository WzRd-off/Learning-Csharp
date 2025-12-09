using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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


    }
}
