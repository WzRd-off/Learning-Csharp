using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR1_2
{
    internal class Test
    {

        public string SubjectName { get; set; }
        public bool IsPassed { get; set; }

        public Test(string subjectName, bool isPassed)
        {
            SubjectName = subjectName;
            IsPassed = isPassed;
        }

        public Test()
        {
            SubjectName = "Unknown";
            IsPassed = false;
        }

        public override string ToString()
        {
            return $"Subject: {SubjectName}, Passed: {IsPassed}";
        }



    }
}
