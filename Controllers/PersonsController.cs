using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Controllers.Resources;
using Persons.Core;
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
        private readonly IUnitOfWork unitOfWork;

        public PersonsController(IPersonRepository personRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<ViewPersonResource>> GetPersonsAsync()
        {
            var persons = await personRepository.GetPersonsEagerAsync();
            return mapper.Map<IEnumerable<Person>, IEnumerable<ViewPersonResource>>(persons);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonAsync([FromBody] SavePersonResource savePersonResource)
        {
            var person = mapper.Map<SavePersonResource, Person>(savePersonResource);

            personRepository.Add(person);
            await unitOfWork.CompleteAsync();

            person = await personRepository.GetPersonEagerAsync(person.Id);

            return Ok(mapper.Map<Person, ViewPersonResource>(person));
        }
    }
}