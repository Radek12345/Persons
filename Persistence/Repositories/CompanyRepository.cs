using Microsoft.EntityFrameworkCore;
using Persons.Core.Domain;
using Persons.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(PersonsDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Company>> GetCompaniesWithBranchesAsync()
        {
            return await Context.Companies.Include(c => c.Branches).ToListAsync();
        }
    }
}
