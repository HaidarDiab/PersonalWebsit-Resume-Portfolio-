using Microsoft.AspNet.Identity;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
	public class ProfilesController : Controller
	{
		private ApplicationDbContext _context;

		public ProfilesController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			var userId = User.Identity.GetUserId();
			var profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId);

			if (profile == null)
				return HttpNotFound();

			var viewModel = new ProfileFormViewModel
			{
				Profile = profile,
				Profiles = _context.Profiles.ToList(),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};


			return View(viewModel);
		}

		[Authorize]
		[HttpGet]
		public ActionResult Create()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				Profiles = _context.Profiles.ToList(),
				ApplicationUser = _context.Users.Single(u => u.Id == userId),
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);

		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ProfileFormViewModel viewModel, HttpPostedFileBase file)
		{
			var userId = User.Identity.GetUserId();
			var applicationUser = _context.Users.Single(u => u.Id == userId);


			//if (!ModelState.IsValid)
			//	return View("Create");



			//cheack if User Has profile >> if Has then dont add profile
			if (_context.Profiles.Any(p => p.ApplicationUserId == userId))
				return View("Create", viewModel);



			if (file != null && file.ContentLength > 0)
			{
				string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(file.FileName));
				file.SaveAs(path);

				var profile = new Profile
				{
					ApplicationUserId = userId,
					FullName = viewModel.FullName,
					Birthday = viewModel.GetDate(),
					Email = viewModel.Email,
					Phone = viewModel.Phone,
					Address = viewModel.Address,
					Website = viewModel.Website,
					ImageName = file.FileName,
					ImagePath = path,
				};

				_context.Profiles.Add(profile);

				_context.SaveChanges();
			}

			return RedirectToAction("Index", "Profiles");

		}



		[Authorize]
		public ActionResult Edit(int id)
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.Single(p => p.Id == id),
				ApplicationUserId = userId,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);

		}



		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(Profile profile, HttpPostedFileBase file)
		{
			var userId = User.Identity.GetUserId();
			var profileInDb = _context.Profiles.Single(p => p.Id == profile.Id && p.ApplicationUserId == userId);


			if (profile == null)
				return HttpNotFound();



			if (file != null && file.ContentLength > 0)
			{
				string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(file.FileName));
				profileInDb.ImageFile = file;
				profileInDb.ImageName = file.FileName;
				profileInDb.ImagePath = path;

				file.SaveAs(path);
			}
			else
			{
				profileInDb.ImageName = profileInDb.ImageName;
				profileInDb.ImagePath = profileInDb.ImagePath;
			}

			profileInDb.FullName = profile.FullName;
			profileInDb.Birthday = DateTime.Parse(string.Format("{0}", profile.Birthday));
			profileInDb.Email = profile.Email;
			profileInDb.Phone = profile.Phone;
			profileInDb.Address = profile.Address;
			profileInDb.Website = profile.Website;
			


			_context.SaveChanges();


			return RedirectToAction("Index", "Profiles");
		}



	}
}