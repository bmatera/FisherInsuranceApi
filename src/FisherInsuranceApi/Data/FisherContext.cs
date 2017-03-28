using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FisherInsuranceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FisherInsuranceApi.Data
{
    public class FisherContext : IdentityDbContext<ApplicationUser>

    //public class FisherContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //note two backslashes, addition of password and semicolons at end.
            string connection = "Data Source = WUSWM100002-YWG\\SQLEXPRESS;Initial Catalog = fisher-insurance; User ID = fisher-user; Password=fisher;";

            optionsBuilder.UseSqlServer(connection);
        }

    public DbSet<Claim> Claims { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    }
}
