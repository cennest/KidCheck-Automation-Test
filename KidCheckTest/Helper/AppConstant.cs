﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.Helper
{
    class AppConstant
    {
        public const int SleepTime = 500;
        private const string BaseURL = "https://localhost";
        public static string SignUpURL = string.Format("{0}/signup/", BaseURL);
        public static string SignInURL = string.Format("{0}/signin.aspx", BaseURL);
    }
}
