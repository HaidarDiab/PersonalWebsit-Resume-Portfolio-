using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
	public class WorkExperience
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public string Description { get; set; }

		public ApplicationUser ApplicationUser { get; set; }
		public string ApplicationUserId { get; set; }
	}
}