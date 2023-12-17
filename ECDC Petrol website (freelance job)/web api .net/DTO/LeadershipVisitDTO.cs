﻿using System.ComponentModel;

namespace TempProject.DTO
{
    public class LeadershipVisitDTO
    {
        public int id { get; set; }

        public string LeaderShipType { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
