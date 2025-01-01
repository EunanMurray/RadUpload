using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022ClassLibrary.Models
{
    public class Players
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Position { get; set; }
        public bool Registered { get; set; }
        public int TeamID { get; set; }
        public virtual Teams Team { get; set; }

    }
}
