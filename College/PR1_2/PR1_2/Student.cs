using PR1_2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PR1_2
{

    internal class StudentEnumerator : IEnumerator
    {
        private List<string> commonSubjects;
        private int position = -1;

        public StudentEnumerator(List<Test> tests, List<Exam> exams)
        {
            var testNames = tests.Select(t => t.SubjectName);
            var examNames = exams.Select(e => e.SubjectName);
            commonSubjects = testNames.Intersect(examNames).ToList();
        }

        public object Current
        {
            get
            {
                if (position == -1 || position >= commonSubjects.Count)
                    throw new InvalidOperationException();
                return commonSubjects[position];
            }
        }

        public bool MoveNext()
        {
            if (position < commonSubjects.Count - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    internal class Student: Person, IDateAndCopy, IEnumerable
    {
        private Person person;
        private Education education;
        private int groupNumber;
        private List<Test> tests;
        private List<Exam> exams;

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(tests, exams);
        }


        public Person Person { get => person; set => person = value; }
        public Education Education { get => education; set => education = value; }

        public int GroupNumber { 
            get => groupNumber; 
            set 
            { 
                if (value <= 100 || value >= 599) 
                { 
                    throw new ArgumentOutOfRangeException("GroupNumber", "Значення повинно бути в межах від 101 до 598."); 
                } 
                groupNumber = value; 
            } 
        }
        public List<Test> Tests { get => tests; set => tests = value; }
        public List<Exam> Exams { get => exams; set => exams = value; } 
        public double AverageScore
        {
            get
            {
                if (Exams.Count == 0)
                    return 0.0;
                return Exams.Average(exam => exam.Score);
            }
        }
        public bool this[Education edu]
        {
            get { return Education == edu; }
        }

        public Student(Person person, Education education, int groupNumber)
        {
            Person = person;
            Education = education;
            GroupNumber = groupNumber;
            Exams = new List<Exam>();
            Tests = new List<Test>();
        }
        public Student()
        {
            Person = new Person();
            Education = Education.Bachelor;
            GroupNumber = 0;
            Exams = new List<Exam>();
            Tests = new List<Test>();
        }
        public void addExam(params Exam[] exam)
        {
            Exams.AddRange(exam);
        }

        public override object DeepCopy()
        {
            return new Student(Person, Education, GroupNumber);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Person.ToString());
            sb.AppendLine($"Education: {Education}, Group Number: {GroupNumber}");
            sb.AppendLine("Exams:");
            foreach (var exam in Exams)
            {
                sb.AppendLine(exam.ToString());
            }
            return sb.ToString();
        }

        public override string ToShortString()
        {
            return $"{Person.ToShortString()}, Education: {Education}, Group Number: {GroupNumber}, Average score: {AverageScore}";
        }

        public IEnumerable<object> GetAllTestsAndExams()
        {
            foreach (var t in tests) yield return t;
            foreach (var e in exams) yield return e;
        }

        public IEnumerable<Exam> GetExamsWithScoreAbove(int threshold)
        {
            foreach (var exam in exams)
            {
                if (exam.Score > threshold)
                    yield return exam;
            }
        }

        public IEnumerable<object> GetPassedExamsAndTests()
        {
            foreach (var exam in exams)
            {
                if (exam.Score > 2) yield return exam;
            }
            foreach (var test in tests)
            {
                if (test.IsPassed) yield return test;
            }
        }

        public IEnumerable<Test> GetPassedTestsWithPassedExams()
        {
            var passedExamSubjects = exams
                .Where(e => e.Score > 2)
                .Select(e => e.SubjectName)
                .ToList();

            foreach (var test in tests)
            {
                if (test.IsPassed && passedExamSubjects.Contains(test.SubjectName))
                {
                    yield return test;
                }
            }
        }

    }
}
