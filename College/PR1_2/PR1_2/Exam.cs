using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR1_2;

namespace PR1_2
{
    internal class Exam: IDateAndCopy
    {
        public string SubjectName { get; set; }
        public int Score { get; set; }

        public DateTime Date { get; set; }
        public Exam(string subject, int score, DateTime examDate)
        {
            SubjectName = subject;
            Score = score;
            Date = examDate;
        }

        public Exam()
        {
            SubjectName = "Unknown";
            Score = 0;
            Date = DateTime.MinValue;
        }

        public override string ToString()
        {
            return $"Subject: {SubjectName}, Score: {Score}, Exam Date: {Date.ToShortDateString()}";
        }

        public object DeepCopy()
        {
            return new Exam(SubjectName, Score, Date);
        }

    }
}
