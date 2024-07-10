using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<EmployeeLeave> EmployeeLeave { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeLeave>(entity =>
            {
                entity.HasKey(e => e.EmployeeLeaveId);
                entity.Property(e => e.LeaveDescription).IsRequired();
                entity.Property(e => e.Status).HasDefaultValue(false);
                entity.HasOne(e => e.Employee)
                      .WithMany(e => e.EmployeeLeaves)
                      .HasForeignKey(e => e.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
