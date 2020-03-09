using BookStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStudy.DBConnect
{
    public class ApplicationContext : DbContext
    {
        public DbSet<GuestResponse> GuestResponses { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //create a DB all the same time with connection
            Database.EnsureCreated();
        }
    }
}