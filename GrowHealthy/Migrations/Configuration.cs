
#region

using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using GrowHealthy.Models;
using WebMatrix.WebData;

#endregion

namespace GrowHealthy.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
                "DefaultConnection",
                "UserProfile",
                "UserId",
                "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!WebSecurity.UserExists("minar09"))
                WebSecurity.CreateUserAndAccount(
                    "minar09",
                    "0905105",
                    new { Contact = "+8801925348037" });

            if (!Roles.GetRolesForUser("minar09").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "minar09" }, new[] { "Administrator" });
        }
    }
}

