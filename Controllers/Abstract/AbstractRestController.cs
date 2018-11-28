using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Core;
using Persons.Core.Repositories;

namespace Persons.Controllers.Abstract
{
    public abstract class AbstractRestController<TRepository, TEntity, TReadResource, TSaveResource> 
        : AbstractReadOnlyRestController<TRepository, TEntity, TReadResource> 
        where TEntity : class where TRepository : IRepository<TEntity>
    {
        public AbstractRestController(TRepository repository, IMapper mapper, IUnitOfWork unitOfWork) 
            : base(repository, mapper, unitOfWork)
        {
        }

        [HttpPost]
        public virtual IActionResult Create([FromBody] TSaveResource saveResource)
        {
            var entity = mapper.Map<TSaveResource, TEntity>(saveResource);

            repository.Add(entity);
            unitOfWork.Complete();

            return Ok(mapper.Map<TEntity, TReadResource>(entity));
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(int id, [FromBody] TSaveResource saveResource)
        {
            var entity = repository.Get(id);

            if (entity == null)
                return NotFound();

            mapper.Map<TSaveResource, TEntity>(saveResource, entity);
            unitOfWork.Complete();

            return Ok(mapper.Map<TEntity, TReadResource>(entity)); ;
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            var entity = repository.Get(id);

            if (entity == null)
                return NotFound();

            repository.Remove(entity);
            unitOfWork.Complete();

            return Ok(id);
        }
    }
}
