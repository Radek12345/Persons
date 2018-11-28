using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Controllers.Abstract;
using Persons.Controllers.Resources;
using Persons.Core;
using Persons.Core.Domain;
using Persons.Core.Repositories;

namespace Persons.Controllers
{
    [Route("/api/persons")]
    public class PersonsController : AbstractRestController<IPersonRepository, Person, ReadPersonResource, SavePersonResource>
    {
        public PersonsController(IPersonRepository repository, IMapper mapper, IUnitOfWork unitOfWork) 
            : base(repository, mapper, unitOfWork) { }
    }
}