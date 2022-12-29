using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLL.Security.Identity
{
    public abstract class User
    {
        public string Name { get; }
        public string Surname { get; }
        public int UserId { get; }
        public string Login { get; }
        public string Email { get; }
        protected string UserType { get; }
        public User(int UserId, string Name,string Surname, string Login, string Email, string UserType)
        {
            this.UserId = UserId;
            this.Name = Name;
            this.Surname = Surname;
            this.Login = Login;
            this.Email = Email;
            this.UserType = UserType;
        }
    }
}
