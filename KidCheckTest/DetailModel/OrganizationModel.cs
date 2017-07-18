using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.DetailModel
{
    class OrganizationModel
    {
        public OrganizationModel()
        {
            OrganizationName = "Cenn";
            Website = "cenn.com";
            MainPhoneNumber = "123-456-7899";
            MailingAddress = "217,seattle";
            City = "seattle";
            PostalCode = "123456";
        }

        public string OrganizationName { get; set; }
        public string Website { get; set; }
        public string MainPhoneNumber { get; set; }
        public string MailingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
       
    }
}
