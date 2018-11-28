using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Controllers.Abstract;
using Persons.Controllers.Resources;
using Persons.Core;
using Persons.Core.Domain;
using Persons.Core.Repositories;

namespace Persons.Controllers
{
    [Route("/api/cities")]
    public class CitiesController : AbstractReadOnlyRestController<IRepository<City>, City, KeyValuePairResource>
    {
        public CitiesController(IRepository<City> repository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(repository, mapper, unitOfWork) { }
    }
}
