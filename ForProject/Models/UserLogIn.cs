using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForProject.Models
{
    public class UserLogIn
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<CreateUser> CreateUser { get; set; }
    }
}
