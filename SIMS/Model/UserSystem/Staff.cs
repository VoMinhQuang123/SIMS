using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model.User
{
    public class Staff : User
    {
        public string Department { get; set; }

        public Staff(int id, string name, string email, string department)
            : base(id, name, email)
        {
            Department = department;
        }
    }
}
