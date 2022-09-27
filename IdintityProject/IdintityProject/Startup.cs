using IdintityProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdintityProject.Startup))]
namespace IdintityProject
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();
            
        }



        public void CreateUsers()
        {
            var UserManager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = new ApplicationUser();
            user.Email = "wasemjbaren99@gmail.com";
            user.UserName = "testAdmin";
            var check = UserManager.Create(user, "Admin12345@");
            if (check.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Admins");
            }


        }



        public void CreateRoles()
        {

            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role ;

            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Teachers"))
            {
                role = new IdentityRole();
                role.Name = "Teachers";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Students"))
            {
                role = new IdentityRole();
                role.Name = "Students";
                roleManager.Create(role);
            }

        }

        
    }
}
