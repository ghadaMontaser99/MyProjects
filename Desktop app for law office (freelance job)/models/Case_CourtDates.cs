using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.models
{
    public class Case_CourtDates
    {
        public int Id { get; set; }
        [ForeignKey("CourtDates")]
        public int Court_DatesId { get;set; }
        public CourtDates CourtDates { get; set; }
        [ForeignKey("Case")]
        public int CaseID { get; set; }
        public Case Case { get; set; }
        public bool IsDeleted { get; set; } = false;

	}
}
