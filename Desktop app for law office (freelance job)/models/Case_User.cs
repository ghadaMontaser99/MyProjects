using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.models
{
    public class Case_User
    {
        public int Id { get; set; } 
        public int CaseId { get; set; }
        public Case Case { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }

        public string Action { get; set; }

        public bool IsDeleted { get; set; } = false;

	}
}
