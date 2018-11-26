using System.Collections.Generic;
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

        public async Task<IEnumerable<Person>> GetPersonsEager()
        {
            return await Context.Persons
                .Include(p => p.City)
                .Include(p => p.CompanyBranch)
                    .ThenInclude(cb => cb.Company)
                .ToListAsync();
        }
    }
}
