using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DatingsiteSpice.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string Nickname { get; set; }
        public GeslachtEnum Geslacht { get; set; }
        public double Lengte { get; set; }
        public EtniciteitEnum Etniciteit { get; set; }
        public string Woonplaats { get; set; }
        public OpleidingsniveauEnum Opleidingsniveau { get; set; }
        public string Interesses { get; set; }
        public string Afbeelding { get; set; }
        public string FotoAlbum { get; set; }

        public enum GeslachtEnum
        {
            Man,
            Vrouw,

            Onbekend
        }

        public enum EtniciteitEnum
        {
            Aziatisch,

        }

        public enum OpleidingsniveauEnum
        {
            Man,
            Vrouw,

            Onbekend
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
    }
}