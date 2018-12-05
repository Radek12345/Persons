using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Persons.Core.Domain;
using Persons.Core.Repositories;

namespace Persons.Persistence.Repositories
{
    public class OpinionRepository : Repository<Opinion>, IOpinionRepository
    {
        public OpinionRepository(PersonsDbContext context) : base(context)
        {
        }

        public override IEnumerable<Opinion> GetAll()
        {
            return Context.Opinions.Include(o => o.Comments).ToList();
        }
    }
}