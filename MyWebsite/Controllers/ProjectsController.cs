using Microsoft.AspNet.Identity;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyWebsite.Controllers
{
	public class ProjectsController : Controller
	{
		private ApplicationDbContext _context;

		public ProjectsController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				Projects = _context.Projects.OrderByDescending(p => p.ReleaseDate).ToList(),
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}


		public ActionResult Description(int id)
		{
			var userId = User.Identity.GetUserId();
			
			var viewModel = new ProfileFormViewModel
			{
				Project = _context.Projects.SingleOrDefault(p => p.Id == id),
				Profile = _context.Profiles.SingleOrDefault(),
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}




		[Authorize]
		[HttpGet]
		public ActionResult Add()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				ApplicationUserId = userId,
				Profile = _context.Profiles.Single(p => p.ApplicationUserId == userId),
				Projects = _context.Projects.ToList(),
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}





		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(ProfileFormViewModel viewModel, HttpPostedFileBase file)
		{

			var userId = User.Identity.GetUserId();

			var exists = _context.Projects.Any(p => p.ApplicationUserId == userId && p.Name == viewModel.Project.Name);

			if (exists)
			{
				ViewBag.Message = "The name already exists..";
				return RedirectToAction("Add", "Projects");
			}


			if (file != null && file.ContentLength > 0)
			{
				string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(file.FileName));

			var pro = new Project
			{
				ApplicationUserId = userId,
				Name = viewModel.Project.Name,
				Category = viewModel.Project.Category,
				ReleaseDate = viewModel.Project.ReleaseDate,
				Link = viewModel.Project.Link,
				Description = viewModel.Project.Description,
				Image = file.FileName,
				ImagePath = path,
				ImageFile = file,
			};
				file.SaveAs(path);

			_context.Projects.Add(pro);
			}

			else
			{
				var pro = new Project
				{
					ApplicationUserId = userId,
					Name = viewModel.Project.Name,
					Category = viewModel.Project.Category,
					ReleaseDate = viewModel.Project.ReleaseDate,
					Link = viewModel.Project.Link,
					Description = viewModel.Project.Description,
					Image = null,
					ImagePath = null,
					ImageFile = null,
				};
				_context.Projects.Add(pro);
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Projects");
		}






		[Authorize]
		public ActionResult Edit(int id)
		{
			var userId = User.Identity.GetUserId();
			var project = _context.Projects.Single(p => p.Id == id && p.ApplicationUserId == userId);

			var viewModel = new ProfileFormViewModel
			{
				Project = project,
				Profile = _context.Profiles.SingleOrDefault(p => p.ApplicationUserId == userId),
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}



		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Update(Project project, HttpPostedFileBase file)
		{
			var userId = User.Identity.GetUserId();
			var projectInDb = _context.Projects.Single(p => p.Id == project.Id && p.ApplicationUserId == userId);

			if (project == null)
				return HttpNotFound();

			if (file != null && file.ContentLength > 0)
			{
				string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(file.FileName));
				projectInDb.Image = file.FileName;
				projectInDb.ImagePath = path;
				projectInDb.ImageFile = file;
				file.SaveAs(path);
			}

			else
			{
				projectInDb.ImagePath = projectInDb.ImagePath;
				projectInDb.Image = projectInDb.Image;
			}

			projectInDb.Name = project.Name;
			projectInDb.Category = project.Category;
			projectInDb.ReleaseDate = project.ReleaseDate;
			projectInDb.Link = project.Link;
			projectInDb.Description = project.Description;


			_context.SaveChanges();

			return RedirectToAction("Index", "Projects");
		}


		[Authorize]
		public ActionResult Delete(int id)
		{
			var userId = User.Identity.GetUserId();

			var project = _context.Projects.Single(p => p.Id == id && p.ApplicationUserId == userId);

			_context.Projects.Remove(project);

			_context.SaveChanges();

			 return RedirectToAction("Index", "Projects");
		}

	}


}