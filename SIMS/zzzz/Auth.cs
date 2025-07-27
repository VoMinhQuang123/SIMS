using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.zzzz
{
    public interface Auth
    {
        bool Authenticate(string email, string password);
    }

}
