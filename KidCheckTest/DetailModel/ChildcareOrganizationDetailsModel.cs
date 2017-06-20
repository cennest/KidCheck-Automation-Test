using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.DetailModel
{
    class ChildcareOrganizationDetailsModel
    {
        public ChildcareOrganizationDetailsModel()
        {
            Childcare_OrganizationName = "Cenn";
            Childcare_Website = "cenn.com";
            Childcare_MainPhoneNumber = "123-456-7899";
            Childcare_MailingAddress = "217,seattle";
            Childcare_City = "seattle";
            Childcare_PostalCode = "123456";
        }

        public string Childcare_OrganizationName { get; set; }
        public string Childcare_Website { get; set; }
        public string Childcare_MainPhoneNumber { get; set; }
        public string Childcare_MailingAddress { get; set; }
        public string Childcare_City { get; set; }
        public string Childcare_PostalCode { get; set; }
       
    }
}
