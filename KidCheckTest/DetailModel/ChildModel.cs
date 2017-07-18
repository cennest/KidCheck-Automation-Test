using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.DetailModel
{
    class ChildModel
    {
        public ChildModel()
        {
            Random random = new Random();
            int no = random.Next(1, 130);
            Firstname = string.Format("christin{0}", no);
            Lastname = "perry";
            DateOfBirth = "11/10/2000";
            MedicalAllergy = "Kiwi";
        }
       
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DateOfBirth { get; set; }
        public string MedicalAllergy { get; set; }

    }
}
