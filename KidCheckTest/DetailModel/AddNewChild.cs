using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.DetailModel
{
    class AddNewChild
    {
        public AddNewChild()
        {
            Random random = new Random();
            int no = random.Next(1, 130);
            Child_Firstname = string.Format("christin{0}", no);
            Child_Lastname = "perry";
            Child_DOB = "11/10/2000";
            Child_MedicalORAllergy = "Kiwi";
        }
       
        public string Child_Firstname { get; set; }
        public string Child_Lastname { get; set; }
        public string Child_DOB { get; set; }
        public string Child_MedicalORAllergy { get; set; }

    }
}
