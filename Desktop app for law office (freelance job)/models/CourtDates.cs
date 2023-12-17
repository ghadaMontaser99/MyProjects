using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.models
{
    public  class CourtDates
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual List<Case_CourtDates> Case_CourtDates { get; set; }

    }
}
