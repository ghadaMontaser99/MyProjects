using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.models
{
     public  class Case
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SerialNumber { get; set; }
		public int CaseNumber { get; set; }
		public string ClientName  { get; set;}
       // public string ClinetSSN { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
		[DefaultValue(false)]
		public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<ImagesCases> ImagesCasesList { get; set; }
        public virtual List<Case_CourtDates> Case_CourtDates { get; set; }
        public virtual List<Case_User> Case_UserList { get; set; }
    }
}
