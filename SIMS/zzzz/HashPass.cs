using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.zzzz
{
    public class HashPass
    {
        public string Hash(string password)
        {
            // Mã hóa bằng SHA256
            return password;
        }
        public bool Verify(string input, string hashed)
        {
            return Hash(input) == hashed;
        }
    }
}
