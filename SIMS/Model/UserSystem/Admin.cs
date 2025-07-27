using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model.User
{
    public class Admin : User
    {
        public string Role { get; set; }

        public Admin(int id, string name, string email, string role)
            : base(id, name, email)
        {
            Role = role;
        }
    }
}
