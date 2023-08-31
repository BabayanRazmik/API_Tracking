using API_Tracking.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Tracking.Data
{
    public class IssueDbContext : DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options) :base(options)
        {   
        }

        public DbSet<Issue> Issues { get; set; }
    }
}
