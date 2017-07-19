using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.DetailModel
{
    class AddNewTemplate
    {
        public AddNewTemplate()
        {
            Random random = new Random();
            int no = random.Next(1, 130);
            TemplateName = string.Format("Template_{0}", no);
            Description = "This is the description of template" + TemplateName;
        }

        public string TemplateName { get; set; }
        public string Description { get; set; }
    }
}
