using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Controllers.Resources;
using Persons.Core.Domain;
using Persons.Core.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persons.Controllers
{
    [Route("/api/persons")]
    public class PersonsController : Controller
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonsController(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ViewPersonResource>> GetPersonsAsync()
        {
            var persons = await personRepository.GetPersonsEagerAsync();
            return mapper.Map<IEnumerable<Person>, IEnumerable<ViewPersonResource>>(persons);
        }
    }
}