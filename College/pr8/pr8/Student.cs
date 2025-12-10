    using pr8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace pr8
{
    internal class Student : Person
    {

        private string formEducation;
        private int studentGroup;
        private List<Test> tests;
        private List<Exam> exams;

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

        public List<Test> Tests { get => tests; set => tests = value; }
        public List<Exam> Exams { get => exams; set => exams = value; }

        public Student() : base()
        {
            tests = new List<Test>();
            exams = new List<Exam>();
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth,
            string formEducation, int studentGroup, List<Test> tests, List<Exam> exams)
            : base(firstName, lastName, dateOfBirth)
        {
            this.formEducation = formEducation;
            this.StudentGroup = studentGroup;
            this.tests = new List<Test>(tests);
            this.exams = new List<Exam>(exams);
        }

        public override object DeepCopy()
        {
            return new Student(firstName, lastName, dateOfBirth,
                formEducation, studentGroup,
                new List<Test>(tests), new List<Exam>(exams));
        }

        public IEnumerable<object> GetAllAssessments()
        {
            foreach (var t in tests) yield return t;
            foreach (var e in exams) yield return e;
        }

        public IEnumerable<Exam> GetExamsAboveGrade(int minGrade)
        {
            foreach (var e in exams)
            {
                if (e.Grade > minGrade)
                    yield return e;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" Группа: {StudentGroup}, Форма: {formEducation}, Экзаменов: {exams.Count}, Зачетов: {tests.Count}";
        }

    }
}
