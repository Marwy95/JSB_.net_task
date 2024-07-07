using JSB_.net_task.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace JSB_.net_task.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Models.Task>Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.TeamMember)
                .WithMany(m => m.Tasks)
                .HasForeignKey(t => t.TeamMemberId);
        }
    }
}
