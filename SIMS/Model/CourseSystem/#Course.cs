using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model.CourseSystem.Course
{
    public class Course
    {
        public string Title { get; set; }
        public string Code { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Course other)
                return Code == other.Code;
            return false;
        }

        public override int GetHashCode() => Code.GetHashCode();
    }
}
