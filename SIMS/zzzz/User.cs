using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.zzzz
{
    public class User
    {
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        public User(string email, string password, HashPass hasher)
        {
            Email = email;
            HashedPassword = hasher.Hash(password);
        }
    }
}
