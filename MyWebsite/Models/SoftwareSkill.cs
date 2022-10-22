using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
	public class SoftwareSkill
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Level { get; set; }

		public ApplicationUser ApplicationUser { get; set; }
		public string ApplicationUserId { get; set; }
	}
}