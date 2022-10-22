using Microsoft.AspNet.Identity;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;


namespace MyWebsite.Controllers
{
	public class HomeController : Controller
	{

		private ApplicationDbContext _context;

		public HomeController()
		{
			_context = new ApplicationDbContext();
		}



		public ActionResult Index()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				WorkSpecialtises = _context.WorkSpecialtis.ToList(),
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}

		public ActionResult About()
		{

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				SocialLinks = _context.SocilaLinks.ToList(),
				Educations = _context.Educations.ToList(),
				Education = _context.Educations.SingleOrDefault(e => e.EndDate.ToString().Contains("2022")),
			};

			return View(viewModel);
		}



		public ActionResult Contact()
		{
			var userId = User.Identity.GetUserId();

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				Profiles = _context.Profiles.ToList(),
				WorkSpecialtises = _context.WorkSpecialtis.ToList(),
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}


		//this to send and recieve email using smtp protocol..........
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Contact(ProfileFormViewModel prof, HttpPostedFileBase file)
		{

			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.SingleOrDefault(),
				Profiles = _context.Profiles.ToList(),
				WorkSpecialtises = _context.WorkSpecialtis.ToList(),
				SocialLinks = _context.SocilaLinks.ToList(),
				FullName = prof.FullName,
				Email = prof.Email,
				EmailSubject = prof.EmailSubject,
				Message = prof.Message,
			};


			if (!ModelState.IsValid)
			{
				ViewBag.Error = "Inputs not valid!.., Please try another inputs.";
				return View("Contact", viewModel);
			}
		
			try
			{

				using (MailMessage mm = new MailMessage(prof.Email, ConfigurationManager.AppSettings["toMailAccount"]))
				{
					mm.Subject = prof.EmailSubject;
					mm.Body = "Name: " + prof.FullName + "<br /><br />Email: " + prof.Email + "<br />" + "<br /><br />Body:<br />" + prof.Message;

					if (file != null)
					{
						string fileName = Path.GetFileName(file.FileName);
						mm.Attachments.Add(new Attachment(file.InputStream, fileName));
					}
		
						mm.IsBodyHtml = true;

					using (SmtpClient smtp = new SmtpClient())
					{
						smtp.Host = ConfigurationManager.AppSettings["host"];
						smtp.EnableSsl = true;

						NetworkCredential networkCred = new NetworkCredential(ConfigurationManager.AppSettings["fromMailAccount"], ConfigurationManager.AppSettings["mailPassword"]);

						smtp.UseDefaultCredentials = true;
						smtp.Credentials = networkCred;
						smtp.Port = int.Parse(ConfigurationManager.AppSettings["port"]);
						smtp.Send(mm);
						ViewBag.Message = "Email has been sent sucessfully.";
					}
				}

			}

			catch (Exception)
			{
				ViewBag.Error = "Sending failed, please try again....";
			}
			return View(viewModel);

		}




		[Authorize]
		[HttpGet]
		public ActionResult IndexDashboardHai(string id)
		{
			var userId = User.Identity.GetUserId();
			var applicationUser = _context.Users.Single(u => u.Id == userId);


			if (userId != id)
				return RedirectToAction("Index", "Home");


			var viewModel = new ProfileFormViewModel
			{
				Profile = _context.Profiles.Single(p => p.ApplicationUserId == userId),
				ApplicationUser = applicationUser,
				SocialLinks = _context.SocilaLinks.ToList(),
			};

			return View(viewModel);
		}
	}
}