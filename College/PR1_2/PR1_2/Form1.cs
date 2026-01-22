using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR1_2
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


    }
}
