using Persons.Core.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persons.Core.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<IEnumerable<Person>> GetPersonsEager();  
    }
}
