using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
	public class Education
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string UniversityName { get; set; }
		public string SpecialistName { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Description { get; set; }

		public ApplicationUser ApplicationUser { get; set; }
		public string ApplicationUserId { get; set; }
	}
}