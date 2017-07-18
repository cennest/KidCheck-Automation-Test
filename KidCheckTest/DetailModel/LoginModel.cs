using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.DetailModel
{
    class LoginModel
    {
        public LoginModel()
        {
            UserName = "KidcheckAutomationTest";
            Password = "cennes";
        }
        public LoginModel(string userRole)
        {
            switch (userRole)
            {
                case UserRole.KidCheckAdmin:
                    UserName = "cennesttest@cennest.com";
                    Password = "cennest";
                    break;
                case UserRole.Administrator:
                    UserName = "nilesh.bhor@cennest.com";
                    Password = "cennest";
                    break;
            }

        }
        public string UserName { get; set; }

        public string Password { get; set; } 
    }
}
