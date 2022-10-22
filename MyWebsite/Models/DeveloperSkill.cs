using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
	public class DeveloperSkill
	{
		public int Id { get; set; }
		public string Description { get; set; }

		public ApplicationUser ApplicationUser { get; set; }
		public string ApplicationUserId { get; set; }
	}
}