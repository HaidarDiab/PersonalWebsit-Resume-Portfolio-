using MyWebsite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MyWebsite.ViewModels
{
	public class ProfileFormViewModel
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Full Name")]
		public string FullName { get; set; }

		//[Required]
		public string Birthday { get; set; }


		// for login form and register form also.................
		[Required]
		[Display(Name = "Email")]
		[EmailAddress]
		public string Email { get; set; }



		//[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }



		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }



		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }

		//..................Also for login form and register form.............................



		// for contact page to send Email

		[Required]
		[Display(Name = "Subject")]
		public string EmailSubject { get; set; }


		[Required]
		[AllowHtml]
		public string Message { get; set; }

		//...............end send email....................



		//[Required]
		public string Phone { get; set; }

		//[Required]
		public string Address { get; set; }

		//[Required]
		public string Website { get; set; }

		public string ImageName { get; set; }

		public string ImagePath { get; set; }

		[NotMapped]
		public HttpPostedFileBase ImageFile { get; set; }


		public Profile Profile { get; set; }

		public int ProfileId { get; set; }

		public IEnumerable<Profile> Profiles { get; set; }


		public Project Project { get; set; }
		public int ProjectId { get; set; }

		public IEnumerable<Project> Projects { get; set; }
		
		
		public ApplicationUser ApplicationUser { get; set; }
		public string ApplicationUserId { get; set; }

		public Education Education { get; set; }
		public IEnumerable<Education> Educations { get; set; }

		public Summary Summary { get; set; }
		public IEnumerable<Summary> Summaries { get; set; }


		public WorkExperience WorkExperience { get; set; }
		public int WorkExperienceId { get; set; }

		public IEnumerable<WorkExperience> WorkExperiences { get; set; }

		public WorkSpecialtis WorkSpecialtis { get; set; }
		public int WorkSpecialtisId { get; set; }

		public IEnumerable<WorkSpecialtis> WorkSpecialtises { get; set; }

		public PersonalSkill PersonalSkill { get; set; }
		public int PersonalSkillId { get; set; }

		public IEnumerable<PersonalSkill> PersonalSkills { get; set; }

		public DeveloperSkill DeveloperSkill { get; set; }
		public int DeveloperSkillId { get; set; }

		public IEnumerable<DeveloperSkill> DeveloperSkills { get; set; }


		public SoftwareSkill SoftwareSkill { get; set; }
		public int SoftwareSkillId { get; set; }

		public IEnumerable<SoftwareSkill> SoftwareSkills { get; set; }

		public Language Language { get; set; }
		public int LanguageId { get; set; }

		public IEnumerable<Language> Languages { get; set; }


		public SocialLink SocialLink { get; set; }
		public IEnumerable<SocialLink> SocialLinks { get; set; }

		public DateTime GetDate()
		{
			return DateTime.Parse(string.Format("{0}", Birthday));
		}
	}
}