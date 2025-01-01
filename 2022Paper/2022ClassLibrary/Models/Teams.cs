using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022ClassLibrary.Models
{
    public class Teams
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public virtual ICollection<Players> Players { get; set; }
    }
}
