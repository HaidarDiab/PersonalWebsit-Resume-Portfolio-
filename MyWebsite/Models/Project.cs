using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyWebsite.Models
{
	public class Project
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[Required]
		[StringLength(100)]
		public string Category { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }

		[Required]
		[StringLength(250)]
		public string Link { get; set; }

		[Required]
		[StringLength(550)]
		public string Description { get; set; }


		//stores image name to use it to display project images using css....
		public string Image { get; set; }


		//used to store image path which the image saved in...its real local path
		public string ImagePath { get; set; }

		[NotMapped]
		public HttpPostedFileBase ImageFile { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		[Required]
		public string ApplicationUserId { get; set; }
	}
}