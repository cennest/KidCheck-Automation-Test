using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidCheckTest.DetailModel
{
    class TemplateModel
    {
        public TemplateModel()
        {
            Random random = new Random();
            int no = random.Next(1, 130);
            Name = string.Format("Template_{0}", no);
            Description = string.Format("This is the description of template ", Name);
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
