using Api_Advert_assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Advert_assignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ad> AdDbSet { get; set; }
    }

}
