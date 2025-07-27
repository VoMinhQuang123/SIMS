using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model.User
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string HashedPassword { get; set; }

        protected User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public User(string email, string hashedPassword)
        {
            Email = email;
            HashedPassword = hashedPassword;
        }
    }
}
