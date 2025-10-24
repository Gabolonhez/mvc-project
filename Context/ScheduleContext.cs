using Microsoft.EntityFrameworkCore;
using mvc_project.Models;

namespace mvc_project.Context
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
