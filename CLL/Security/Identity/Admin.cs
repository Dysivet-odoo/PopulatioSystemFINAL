using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLL.Security.Identity
{
    public class Admin 
        : User
    {
        public Admin(int UserId, string Name, string Surname, string Login, string Email)
            : base(UserId, Name, Surname, Login, Email, nameof(Admin))
        {

        }
    }
}
