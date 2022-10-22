using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyWebsite.Models
{

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Profile> Profiles { get; set; }

		public DbSet<Project> Projects { get; set; }

		public DbSet<SocialLink> SocilaLinks { get; set; }

		public DbSet<Education> Educations { get; set; }

		public DbSet<DeveloperSkill> DeveloperSkills { get; set; }

		public DbSet<SoftwareSkill> SoftwareSkills { get; set; }

		public DbSet<PersonalSkill> PersonalSkills { get; set; }

		public DbSet<Language> Languages { get; set; }

		public DbSet<WorkExperience> WorkExperiences { get; set; }

		public DbSet<WorkSpecialtis> WorkSpecialtis { get; set; }

		public DbSet<Summary> Summaries { get; set; }

		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}


		//to ignore HttpPostFilwBasedfrom Dbcontext Changes...

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Project>().Ignore(t => t.ImageFile);
		//	base.OnModelCreating(modelBuilder);
		//}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}