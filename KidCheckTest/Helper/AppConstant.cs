using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.Helper
{
    class AppConstant
    {
        public const int WaitTimeApi = 7000;
        private const string ServerURL = "https://localhost";
        public static string SignUpURL = string.Format("{0}/signup/", ServerURL);
        public static string SignInURL = string.Format("{0}/signin.aspx", ServerURL);
    }
}
