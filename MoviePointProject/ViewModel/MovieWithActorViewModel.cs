﻿using MoviePoint.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviePoint.ViewModel
{
	public class MovieWithActorViewModel
	{
		public string MovieName { get; set; }

        public List<Actor> Actors { get; set; }

        public string MoviePicture { get; set; }

		public string MovieDescription { get; set; }

		public DateTime MovieStartDate { get; set; }

		public DateTime MovieEndDate { get; set; }
	}
}
