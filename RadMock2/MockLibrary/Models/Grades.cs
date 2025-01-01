using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MockLibrary.Models
{
    public class Grades
    {
        public int GradeID { get; set; }
        public string SubjectTitle { get; set; }
        public int Grade { get; set; }
        public DateTime DateEntered { get; set; }

        public string StudentID { get; set; }
        public virtual Students Student { get; set; }
    }
}
