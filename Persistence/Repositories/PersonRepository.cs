using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persons.Core.Domain;
using Persons.Core.Repositories;

namespace Persons.Persistence.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonsDbContext context) : base(context)
        {
        }

        public override IEnumerable<Person> GetAll()
        {
            return Context.Persons
                .Include(p => p.City)
                .Include(p => p.CompanyBranch)
                    .ThenInclude(cb => cb.Company)
                .ToList();
        }

        public override Person Get(int id)
        {
            return Context.Persons
                .Include(p => p.City)
                .Include(p => p.CompanyBranch)
                    .ThenInclude(cb => cb.Company)
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
