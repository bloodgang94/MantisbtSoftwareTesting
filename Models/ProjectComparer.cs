using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantisbt.Models
{
    public class ProjectComparer : IEqualityComparer<Project>
    {
        public bool Equals(Project x, Project y)
        {
            return x?.Name == y?.Name && x?.State == y?.State && x?.Visibility == y?.Visibility && x?.Description == y?.Description;
        }

        public int GetHashCode(Project obj)
        {
            return (obj?.Name + ";" + obj?.State).GetHashCode();
        }
    }
}
