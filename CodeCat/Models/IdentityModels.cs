using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Threading;

namespace CodeCat.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here  
            return userIdentity;
        }
    }

    public interface IAppDataContext
    {
        IDbSet<UserModel> UserModel { get; set; }
        IDbSet<DocumentModel> DocumentModel { get; set; }
        IDbSet<ProjectModel> ProjectModel { get; set; }
        IDbSet<UserProjectModel> UserProjectModel { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }

        // IDbSet<UserModel> Users { get; set; }

        int SaveChanges();

        //System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IAppDataContext
    {
        public IDbSet<ProjectModel> ProjectModel { get; set; }
        public IDbSet<DocumentModel> DocumentModel { get; set; }
        public IDbSet<UserModel> UserModel { get; set; }
        public IDbSet<UserProjectModel> UserProjectModel { get; set; }
      //  public IDbSet<ApplicationUser> ApplicationUser { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}