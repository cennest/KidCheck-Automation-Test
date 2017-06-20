using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidCheckTest.Helper;


namespace KidCheckTest.DetailModel
{
    class SignupDetailsModel
    {

        public SignupDetailsModel()
        {
            Random random = new Random();
            int no = random.Next(1, 130);

            Account_FirstName = "KidCheckTest" + no;
            Account_Lastname = "test";
            Account_EmailID = "KidCheckTest" + no + "@gmail.com";
            Account_UserName = "KidCheckTest" + no;
            Account_Password = "cennest";
            Account_ConfirmPassword = "cennest";
            Account_PhoneNumber = ActionHelper.GenerateNumber();
            Account_MailingAddress = "217,seattle";
            Account_City = "seattle";
            Account_PostalCode = "123456";
            Account_MobileNumber = ActionHelper.GenerateNumber();
        }            

        public string Account_FirstName { get; set; }
        public string Account_Lastname { get; set; }
        public string Account_EmailID { get; set; }
        public string Account_Password { get; set; }
        public string Account_ConfirmPassword { get; set; }
        public string Account_PhoneNumber { get; set; }
        public string Account_MobileNumber { get; set; }
        public string Account_UserName { get; set; }
        public string Account_MailingAddress { get; set; }
        public string Account_City { get; set; }
        public string Account_PostalCode { get; set; }
    }
}
