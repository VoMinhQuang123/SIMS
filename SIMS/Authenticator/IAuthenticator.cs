using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Model.User;

namespace SIMS.Authenticator
{
    public interface IAuthenticator
    {
        bool Authenticate(string email, string password);
    }
}
