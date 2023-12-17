﻿using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
    public class LeadershipVisit : ISoftDeleteRepository
    {
        public int Id { get; set; }

        public string LeadershipType { get; set; }
		public virtual List<LeaderShipVisitsAndQHSEDaily> LeaderShipVisitsAndQHSEDaily { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
