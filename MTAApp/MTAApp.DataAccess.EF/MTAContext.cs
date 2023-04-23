using Microsoft.EntityFrameworkCore;
using MTAApp.DataAccess.Model;


namespace MTAApp.DataAccess.EF
{
    public class MTAContext : DbContext
    {
        public MTAContext(DbContextOptions<MTAContext> options) : base(options) { }

        public DbSet<Association> Associations { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PaymentReport> PaymentReports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
