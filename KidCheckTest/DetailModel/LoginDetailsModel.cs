using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.DetailModel
{
    class LoginDetailsModel
    {
        public LoginDetailsModel()
        {
            UserName = "KidcheckAutomationTest";
            Password = "cennes";
        }
        public LoginDetailsModel(string userRole)
        {
            switch (userRole)
            {
                case UserRole.KidCheckAdmin:
                    UserName = "cennesttest@cennest.com";
                    Password = "cennest";
                    break;
                case UserRole.Administrator:
                    /*  UserName = "poulomeecennest";
                      Password = "cennest";
                      For production site i.e www.kidcheck.com
                      */
                    UserName = "KidCheck@cennest.com";
                    Password = "cennest";
                    break;
                //case UserRole.InvalidUser:
                //    UserName = "cennesttest@cennest.com";
                //    Password = "cennest";
                //    break;
                //default:
                //    UserName = "poulomeecennes";
                //    Password = "cennes";
                //    break;
            }

        }
        public string UserName { get; set; }

        public string Password { get; set; } 
    }
}
