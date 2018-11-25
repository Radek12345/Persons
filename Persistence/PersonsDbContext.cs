using Microsoft.EntityFrameworkCore;
using Persons.Core.Domain;

namespace Persons.Persistence
{
    public class PersonsDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyBranch> CompanyBranches { get; set; }
        public DbSet<City> Cities { get; set; }

        public PersonsDbContext(DbContextOptions<PersonsDbContext> options)
            : base(options)
        {

        }
    }
}
