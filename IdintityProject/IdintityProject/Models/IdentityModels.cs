using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdintityProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Course { get; set; }
        public string Course2 { get; set; }
        public string Course3 { get; set; }
        public string Course4 { get; set; }
        public string Course5 { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {


        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public DbSet<CourseModel> Course { get; set; }
        public DbSet<GradesModel> GradesModel { get; set; }
        public DbSet<StudentGrades> StudentGrades { get; set; }
        public DbSet<StudentRequest> StudentRequest { get; set; }

        public DbSet<HomeWorksModel> HomeWorksModel { get; set; }

        public DbSet<UserRequestsModel> UserRequestsModel { get; set; }

        public DbSet<Exam> Exam { get; set; }

        public System.Data.Entity.DbSet<IdintityProject.Models.UserViewModel> UserViewModels { get; set; }


    }
}