using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr8
{
    internal class Test
    {
        public string Subject { get; set; }
        public bool IsPassed { get; set; }

        public Test() { }

        public Test(string subject, bool isPassed)
        {
            Subject = subject;
            IsPassed = isPassed;
        }

        public override string ToString() => $"{Subject}: {(IsPassed ? "Сдан" : "Не сдан")}";

    }
}
