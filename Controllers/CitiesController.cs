using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Controllers.Resources;
using Persons.Core;
using Persons.Core.Domain;
using Persons.Core.Repositories;
using System.Collections.Generic;

namespace Persons.Controllers
{
    [Route("/api/cities")]
    public class CitiesController
    {
        private readonly IRepository<City> repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CitiesController(IRepository<City> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<SimpleTextResource> GetCities()
        {
            return mapper.Map<IEnumerable<City>, IEnumerable<SimpleTextResource>>(repository.GetAll());
        }
    }
}
