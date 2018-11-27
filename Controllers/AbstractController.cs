using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Core;
using Persons.Core.Repositories;
using System.Collections.Generic;

namespace Persons.Controllers
{
    public abstract class AbstractController<TRepository, TEntity, TReadResource> : Controller where TEntity : class where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository repository;
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;

        public AbstractController(TRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<TReadResource> getAll()
        {
            return mapper.Map<IEnumerable<TEntity>, IEnumerable<TReadResource>>(repository.GetAll());
        }
    }
}
