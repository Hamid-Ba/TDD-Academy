using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Academy.Infrastructure.Context
{
    public class AcademyContext : DbContext
    {
        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }

    }
}