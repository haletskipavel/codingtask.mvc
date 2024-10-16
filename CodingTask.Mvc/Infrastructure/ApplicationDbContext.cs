using CodingTask.Mvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodingTask.Mvc.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleTask> Tasks { get; set; }
    }
}
