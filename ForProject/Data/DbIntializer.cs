using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForProject.Models;

namespace ForProject.Data
{
    public class DbIntializer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();
            // Look for any users.
            if (context.UserLogIn.Any())
            {
                return;   // DB has been seeded
            }
            var user = new CreateUser[]
            {
            new CreateUser{FirstName="Carson",LastName="Alexander",Email="caralex@gmail.com",UserName="caralex",Password="alexcar"},
            new CreateUser{FirstName="Meredith",LastName="Alonso",Email="mereal@gmail.com",UserName="mereal",Password="almere"},
            new CreateUser{FirstName="Arturo",LastName="Anand",Email="artara@gmail.com",UserName="artana",Password="anaart"},
            new CreateUser{FirstName="Gytis",LastName="Barzdukas",Email="gytbar@gmail.com",UserName="gytbar",Password="bargyt"},
            new CreateUser{FirstName="Yan",LastName="Li",Email="yanli@gmail.com",UserName="yanli",Password="liyan"},
            new CreateUser{FirstName="Peggy",LastName="Justice",Email="pegjus@gmail.com",UserName="pegjus",Password="juspeg"},
            new CreateUser{FirstName="Laura",LastName="Norman",Email="launor@gmail.com",UserName="launor",Password="norlau"},
            new CreateUser{FirstName="Nino",LastName="Olivetto",Email="ninoli@gmail.com",UserName="ninoli",Password="olinin"}
            };
            foreach (CreateUser s in user)
            {
                context.CreateUser.Add(s);
            }
            context.SaveChanges();
        }
    }
}
