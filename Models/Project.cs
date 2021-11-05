using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mantisbt.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public bool IsInheritCriteria { get; set; }
        public int Visibility { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}:{3}", Name, State, Visibility, Description);
        }
    }
}
