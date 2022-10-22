using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
	public class Profile
	{
		public int Id { get; set; }
		
		[Display(Name = "Full Name")]
		public string FullName { get; set; }

		public DateTime Birthday { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Address { get; set; }

		public string Website { get; set; }

		//  store image name to use it to display project images...
		public string ImageName { get; set; }

		// store local image path that the image added it...
		public string ImagePath { get; set; }

		[NotMapped]
		public HttpPostedFileBase ImageFile { get; set; }


		public ApplicationUser ApplicationUser { get; set; }

		public string ApplicationUserId { get; set; }


	}
}