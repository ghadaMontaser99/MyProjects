using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.models
{
    public  class ImagesCases
    {
        public int id { get; set; }
        public string name { get; set; }
        public byte[] CaseImage { get; set; }
        public int CaseId { get; set; }
        public Case Case { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
