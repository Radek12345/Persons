using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Core;
using Persons.Core.Repositories;
using System.Collections.Generic;

namespace Persons.Controllers.Abstract
{
    public abstract class AbstractReadOnlyRestController<TRepository, TEntity, TReadResource> : Controller where TEntity : class where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository repository;
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;

        public AbstractReadOnlyRestController(TRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var entity = repository.Get(id);

            if (entity == null)
                return NotFound();

            return Ok(mapper.Map<TEntity, TReadResource>(entity));
        }

        [HttpGet]
        public virtual IEnumerable<TReadResource> GetAll()
        {
            return mapper.Map<IEnumerable<TEntity>, IEnumerable<TReadResource>>(repository.GetAll());
        }
    }
}
