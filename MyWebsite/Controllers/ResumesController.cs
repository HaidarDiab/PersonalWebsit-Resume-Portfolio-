using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
	public class ResumesController : Controller
	{

		private ApplicationDbContext _context;

		public ResumesController()
		{
			_context = new ApplicationDbContext();
		}

		

		public ActionResult Resume()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				ApplicationUser = _context.Users.SingleOrDefault(),
				Summaries = _context.Summaries.OrderBy(m => m.Id).ToList(),
				Educations = _context.Educations.OrderByDescending(m => m.StartDate).ToList(),
				WorkExperiences = _context.WorkExperiences.OrderByDescending(m => m.StartDate).ToList(),
				WorkSpecialtises = _context.WorkSpecialtis.OrderBy(m => m.Id).ToList(),
				PersonalSkills = _context.PersonalSkills.OrderBy(m => m.Id).ToList(),
				DeveloperSkills = _context.DeveloperSkills.OrderBy(m => m.Id).ToList(),
				SoftwareSkills = _context.SoftwareSkills.OrderBy(m => m.Id).ToList(),
				Languages = _context.Languages.OrderBy(m => m.Id).ToList(),
				SocialLinks = _context.SocilaLinks.OrderBy(m => m.Id).ToList(),
			};


			return View(viewModel);
		}





		[Authorize]
		[HttpGet]
		public ActionResult SummaryInsert()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SummaryInsert(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var applicationUser = _context.Users.Single(u => u.Id == userId);

			if (viewModel.Summary.Id == 0 && viewModel.ApplicationUserId == userId)
			{
				var summ = new Summary
				{
					ApplicationUserId = userId,
					ApplicationUser = applicationUser,
					Content = viewModel.Summary.Content,
				};

				_context.Summaries.Add(summ);
			}

			_context.SaveChanges();

			return RedirectToAction("SummaryInsert", "Resumes");
		}


		[Authorize]
		[HttpGet]
		public ActionResult EditSummary(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				Summary = _context.Summaries.SingleOrDefault(s => s.Id == id),
			};

			return View(viewModel);
		}



		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditSummary(Summary summary)
		{
			var userId = User.Identity.GetUserId();
			var summaryInDb = _context.Summaries.Single(s => s.Id == summary.Id && s.ApplicationUserId == userId);

			if (summary == null)
				return HttpNotFound();


			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				Summary = summary,
			};

			summaryInDb.Content = viewModel.Summary.Content;

			_context.SaveChanges();

			return RedirectToAction("Resume", "Resumes");
		}




		[Authorize]
		[HttpGet]
		public ActionResult EducationInsert()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EducationInsert(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var applicationUser = _context.Users.Single(u => u.Id == userId);

			if (viewModel.Education.Id == 0 && viewModel.ApplicationUserId == userId)
			{
				var edu = new Education
				{
					ApplicationUserId = userId,
					ApplicationUser = applicationUser,
					Name = viewModel.Education.Name,
					SpecialistName = viewModel.Education.SpecialistName,
					UniversityName = viewModel.Education.UniversityName,
					Description = viewModel.Education.Description,
					StartDate = viewModel.Education.StartDate == null || viewModel.Education.StartDate == DateTime.MinValue
                    ? DateTime.Now.AddYears(3) : viewModel.Education.StartDate,
					EndDate = viewModel.Education.EndDate == null || viewModel.Education.EndDate == DateTime.MinValue
                    ? DateTime.Now.AddYears(3) : viewModel.Education.EndDate,
				};

				_context.Educations.Add(edu);
			}

			_context.SaveChanges();

			return RedirectToAction("EducationInsert", "Resumes");
		}




		[Authorize]
		[HttpGet]
		public ActionResult EditEducation(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				Education = _context.Educations.SingleOrDefault(e => e.Id == id),
			};

			return View(viewModel);
		}



		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditEducation(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();
			var educationInDb = _context.Educations.Single(e => e.Id == viewModel.Education.Id && e.ApplicationUserId == userId);

			if (viewModel.Education == null)
				return HttpNotFound();


		    educationInDb.Name = viewModel.Education.Name;
			educationInDb.SpecialistName = viewModel.Education.SpecialistName;
			educationInDb.UniversityName = viewModel.Education.UniversityName;
			educationInDb.StartDate = viewModel.Education.StartDate == null || viewModel.Education.StartDate == DateTime.MinValue
                    ? DateTime.Now.AddYears(6) : viewModel.Education.StartDate;
            educationInDb.EndDate = viewModel.Education.EndDate == null || viewModel.Education.EndDate == DateTime.MinValue
                    ? DateTime.Now.AddYears(6) : viewModel.Education.EndDate;

            _context.SaveChanges();

			return RedirectToAction("Resume", "Resumes");
		}





		[Authorize]
		[HttpGet]
		public ActionResult WorkExperienceInsert()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult WorkExperienceInsert(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var applicationUser = _context.Users.Single(u => u.Id == userId);

			if (viewModel.WorkExperienceId == 0 && viewModel.ApplicationUserId == userId)
			{
				var workExperience = new WorkExperience
				{
					ApplicationUserId = userId,
					ApplicationUser = applicationUser,
					Name = viewModel.WorkExperience.Name,
					Description = viewModel.WorkExperience.Description,
					StartDate = viewModel.WorkExperience.StartDate == null || viewModel.WorkExperience.StartDate == DateTime.MinValue
                    ? DateTime.Now.AddYears(6) : viewModel.WorkExperience.StartDate,
					EndDate = viewModel.WorkExperience.EndDate == null || viewModel.WorkExperience.EndDate == DateTime.MinValue
                    ? DateTime.Now.AddYears(6) : viewModel.WorkExperience.EndDate,
				};

				_context.WorkExperiences.Add(workExperience);
			}

			_context.SaveChanges();

			return RedirectToAction("WorkExperienceInsert", "Resumes");
		}




		[Authorize]
		[HttpGet]
		public ActionResult EditWorkexperience(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				WorkExperience = _context.WorkExperiences.SingleOrDefault(w => w.Id == id),
			};

			return View(viewModel);
		}



		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditWorkexperience(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();
			var workInDb = _context.WorkExperiences.Single(e => e.Id == viewModel.WorkExperience.Id && e.ApplicationUserId == userId);

			if (viewModel.WorkExperience == null)
				return HttpNotFound();


			workInDb.Name = viewModel.WorkExperience.Name;
			workInDb.Description = viewModel.WorkExperience.Description;
			workInDb.StartDate = viewModel.WorkExperience.StartDate == null || viewModel.WorkExperience.StartDate == DateTime.MinValue
                    ? DateTime.Now.AddYears(6) : viewModel.WorkExperience.StartDate;
			workInDb.EndDate = viewModel.WorkExperience.EndDate == null || viewModel.WorkExperience.EndDate == DateTime.MinValue
                    ? DateTime.Now.AddYears(6) : viewModel.WorkExperience.EndDate;


            _context.SaveChanges();

			return RedirectToAction("Resume", "Resumes");
		}



		[Authorize]
		[HttpGet]
		public ActionResult WorkSpecialistInsert()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult WorkSpecialistInsert(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var applicationUser = _context.Users.Single(u => u.Id == userId);

			if (viewModel.WorkSpecialtisId == 0 && viewModel.ApplicationUserId == userId)
			{

				var workspicilaist = new WorkSpecialtis
				{
					ApplicationUserId = userId,
					ApplicationUser = applicationUser,
					Name = viewModel.WorkSpecialtis.Name,
					Description = viewModel.WorkSpecialtis.Description,

				};
				_context.WorkSpecialtis.Add(workspicilaist);
			}

			_context.SaveChanges();

			return RedirectToAction("WorkSpecialistInsert", "Resumes");
		}

		[Authorize]
		[HttpGet]
		public ActionResult IndexWorkSpecialist()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				WorkSpecialtises = _context.WorkSpecialtis.ToList()
			};

			return View(viewModel);
		}


		[Authorize]
		[HttpGet]
	   public ActionResult EditWorkSpecialist(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				WorkSpecialtis = _context.WorkSpecialtis.SingleOrDefault(w => w.Id == id && w.ApplicationUserId == userId),
			};

			return View(viewModel);

		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditWorkSpecialist(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var workInDb = _context.WorkSpecialtis.SingleOrDefault(w => w.Id == viewModel.WorkSpecialtis.Id && w.ApplicationUserId == userId);

			if (viewModel.WorkSpecialtis == null)
				return HttpNotFound();

			workInDb.Name = viewModel.WorkSpecialtis.Name;
			workInDb.Description = viewModel.WorkSpecialtis.Description;

			_context.SaveChanges();

			return RedirectToAction("IndexWorkSpecialist", "Resumes");

		}


		[Authorize]
		[HttpGet]
		public ActionResult PersonalSkillsInsert()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),

			};

			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult PersonalSkillsInsert(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var applicationUser = _context.Users.Single(u => u.Id == userId);

			if (viewModel.PersonalSkillId == 0 && viewModel.ApplicationUserId == userId)
			{

				var skill = new PersonalSkill
				{
					ApplicationUserId = userId,
					ApplicationUser = applicationUser,
					Description = viewModel.PersonalSkill.Description,

				};
				_context.PersonalSkills.Add(skill);
			}

			_context.SaveChanges();

			return RedirectToAction("PersonalSkillsInsert", "Resumes");
		}




		[Authorize]
		[HttpGet]
		public ActionResult EditPersonalskill(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				WorkSpecialtis = _context.WorkSpecialtis.SingleOrDefault(p => p.Id == id && p.ApplicationUserId == userId),
				PersonalSkill = _context.PersonalSkills.SingleOrDefault(p => p.Id == id && p.ApplicationUserId == userId)
			};

			return View(viewModel);

		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditPersonalskill(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var pers = _context.PersonalSkills.SingleOrDefault(p => p.Id == viewModel.PersonalSkill.Id && p.ApplicationUserId == userId);

			if (viewModel.PersonalSkill == null)
				return HttpNotFound();

			pers.Description = viewModel.PersonalSkill.Description;

			_context.SaveChanges();

			return RedirectToAction("Resume", "Resumes");

		}




		[Authorize]
		[HttpGet]
		public ActionResult SoftwareSkillsInsert()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SoftwareSkillsInsert(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var applicationUser = _context.Users.Single(u => u.Id == userId);

			if (viewModel.SoftwareSkillId == 0 && viewModel.ApplicationUserId == userId)
			{

				var skill = new SoftwareSkill
				{
					ApplicationUserId = userId,
					ApplicationUser = applicationUser,
					Name = viewModel.SoftwareSkill.Name,

				};
				_context.SoftwareSkills.Add(skill);
			}

			_context.SaveChanges();

			return RedirectToAction("SoftwareSkillsInsert", "Resumes");
		}



		[Authorize]
		[HttpGet]
		public ActionResult EditSoftwareskill(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				SoftwareSkill = _context.SoftwareSkills.Single(s => s.Id == id &&  s.ApplicationUserId == userId)
			};

			return View(viewModel);

		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditSoftwareskill(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var softInDb = _context.SoftwareSkills.SingleOrDefault(p => p.Id == viewModel.SoftwareSkill.Id && p.ApplicationUserId == userId);

			if (viewModel.SoftwareSkill == null)
				return HttpNotFound();

			softInDb.Name = viewModel.SoftwareSkill.Name;
			softInDb.Level = viewModel.SoftwareSkill.Level;


			_context.SaveChanges();

			return RedirectToAction("Resume", "Resumes");

		}




		[Authorize]
		[HttpGet]
		public ActionResult DevelopersSkillsInsert()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult DevelopersSkillsInsert(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var applicationUser = _context.Users.Single(u => u.Id == userId);

			if (viewModel.DeveloperSkillId == 0 && viewModel.ApplicationUserId == userId)
			{

				var skill = new DeveloperSkill
				{
					ApplicationUserId = userId,
					ApplicationUser = applicationUser,
					Description = viewModel.DeveloperSkill.Description,

				};
				_context.DeveloperSkills.Add(skill);
			}

			_context.SaveChanges();

			return RedirectToAction("DevelopersSkillsInsert", "Resumes");
		}




		[Authorize]
		[HttpGet]
		public ActionResult EditDeveloperskill(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				DeveloperSkill = _context.DeveloperSkills.SingleOrDefault(s => s.Id == id && s.ApplicationUserId == userId)
			};

			return View(viewModel);

		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditDeveloperskill(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var develop = _context.DeveloperSkills.SingleOrDefault(p => p.Id == viewModel.DeveloperSkill.Id && p.ApplicationUserId == userId);

			if (viewModel.DeveloperSkill == null)
				return HttpNotFound();

			develop.Description = viewModel.DeveloperSkill.Description;

			_context.SaveChanges();

			return RedirectToAction("Resume", "Resumes");

		}





		[Authorize]
		[HttpGet]
		public ActionResult LanguageSkillsInsert()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LanguageSkillsInsert(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var applicationUser = _context.Users.Single(u => u.Id == userId);

			if (viewModel.LanguageId == 0 && viewModel.ApplicationUserId == userId)
			{

				var skill = new Language
				{
					ApplicationUserId = userId,
					ApplicationUser = applicationUser,
					Name = viewModel.Language.Name,

				};
				_context.Languages.Add(skill);
			}

			_context.SaveChanges();

			return RedirectToAction("LanguageSkillsInsert", "Resumes");
		}



		[Authorize]
		[HttpGet]
		public ActionResult EditLanguageskill(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				Language = _context.Languages.SingleOrDefault(s => s.Id == id && s.ApplicationUserId == userId)
			};

			return View(viewModel);

		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditLanguageskill(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var lang = _context.Languages.SingleOrDefault(p => p.Id == viewModel.Language.Id && p.ApplicationUserId == userId);

			if (viewModel.Language == null)
				return HttpNotFound();

			lang.Name = viewModel.Language.Name;

			_context.SaveChanges();

			return RedirectToAction("Resume", "Resumes");
		}






		[Authorize]
		[HttpGet]
		public ActionResult SocialLinkInsert()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SocialLinkInsert(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var applicationUser = _context.Users.Single(u => u.Id == userId);

			if (viewModel.SocialLink.Id == 0 && viewModel.ApplicationUserId == userId)
			{

				var social = new SocialLink
				{
					ApplicationUserId = userId,
					ApplicationUser = applicationUser,
					Name = viewModel.SocialLink.Name,
					Link = viewModel.SocialLink.Link,
				};
				_context.SocilaLinks.Add(social);
			}

			_context.SaveChanges();

			return RedirectToAction("SocialLinkInsert", "Resumes");
		}


		[Authorize]
		[HttpGet]
		public ActionResult SocialLinkIndex()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);

		}


		[Authorize]
		[HttpGet]
		public ActionResult EditSocialLink(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
				SocialLink = _context.SocilaLinks.SingleOrDefault(s => s.Id == id && s.ApplicationUserId == userId)
			};

			return View(viewModel);

		}


		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult EditSocialLink(ProfileFormViewModel viewModel)
		{
			var userId = User.Identity.GetUserId();

			var social = _context.SocilaLinks.SingleOrDefault(p => p.Id == viewModel.SocialLink.Id && p.ApplicationUserId == userId);

			if (viewModel.SocialLink == null)
				return HttpNotFound();

			social.Name = viewModel.SocialLink.Name;
			social.Link = viewModel.SocialLink.Link;

			_context.SaveChanges();

			return RedirectToAction("IndexDashboardHai", "Home");
		}



		[Authorize]
		public ActionResult Delete(int id, string actionName)
		{
			

			var userId = User.Identity.GetUserId();

			switch (actionName)
			{
				case "SocilaLinks":
					_context.SocilaLinks.Remove(_context.SocilaLinks.Single(m => m.Id == id && m.ApplicationUserId == userId));
					break;
				case "Educations":
					_context.Educations.Remove(_context.Educations.Single(m => m.Id == id && m.ApplicationUserId == userId));
					break;
				case "DeveloperSkills":
					_context.DeveloperSkills.Remove(_context.DeveloperSkills.Single(m => m.Id == id && m.ApplicationUserId == userId));
					break;
				case "SoftwareSkills":
					_context.SoftwareSkills.Remove(_context.SoftwareSkills.Single(m => m.Id == id && m.ApplicationUserId == userId));
					break;
				case "PersonalSkills":
					_context.PersonalSkills.Remove(_context.PersonalSkills.Single(m => m.Id == id && m.ApplicationUserId == userId));
					break;
				case "Languages":
					_context.Languages.Remove(_context.Languages.Single(m => m.Id == id && m.ApplicationUserId == userId));
					break;

				case "WorkExperiences":
					_context.WorkExperiences.Remove(_context.WorkExperiences.Single(m => m.Id == id && m.ApplicationUserId == userId));
					break;
				case "WorkSpecialtis":
					_context.WorkSpecialtis.Remove(_context.WorkSpecialtis.Single(m => m.Id == id && m.ApplicationUserId == userId));
					break;
				case "Summaries":
					_context.Summaries.Remove(_context.Summaries.Single(m => m.Id == id && m.ApplicationUserId == userId));
					break;
			}
		
			_context.SaveChanges();

			 return RedirectToAction("Resume", "Resumes");
		}

	}
}