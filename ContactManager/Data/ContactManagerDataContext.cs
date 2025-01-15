using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class ContactManagerDataContext : DbContext
    {
        public ContactManagerDataContext(DbContextOptions<ContactManagerDataContext> options) 
            : base(options){ }

        public DbSet<Contact>? Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(c => c.Salary)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
