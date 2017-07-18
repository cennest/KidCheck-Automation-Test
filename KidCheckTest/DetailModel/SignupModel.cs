using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidCheckTest.Helper;


namespace KidCheckTest.DetailModel
{
    class SignupModel
    {

        public SignupModel()
        {
            Random random = new Random();
            int no = random.Next(1, 130);

            FirstName =  string.Format("Test{0}", no);
            Lastname = "test";
            EmailID = string.Format("test{0}@gmail.com", no);
            UserName = string.Format("test{0}", no);
            Password = "cennest";
            ConfirmPassword = "cennest";
            PhoneNumber = ActionHelper.GenerateNumber();
            MailingAddress = "217, seattle";
            City = "seattle";
            PostalCode = "123456";
            MobileNumber = ActionHelper.GenerateNumber();
        }

        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string UserName { get; set; }
        public string MailingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
