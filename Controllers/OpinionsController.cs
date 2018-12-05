using System;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Persons.Controllers.Abstract;
using Persons.Controllers.Resources;
using Persons.Core;
using Persons.Core.Domain;
using Persons.Core.Repositories;

namespace Persons.Controllers
{
    [Route("/api/opinions")]
    public class OpinionsController : AbstractReadOnlyRestController<IOpinionRepository, Opinion,
        ReadOpinionResource>
    {
        public OpinionsController(IOpinionRepository repository, IMapper mapper, IUnitOfWork unitOfWork) 
            : base(repository, mapper, unitOfWork)
        {
        }

        [HttpPost]
        public IActionResult Create([FromBody] SaveOpinionResource resource) 
        {
            var opinion = mapper.Map<SaveOpinionResource, Opinion>(resource);
            
            opinion.AdditionTime = DateTime.Now;
            repository.Add(opinion);
            unitOfWork.Complete();

            return Ok(mapper.Map<Opinion, ReadOpinionResource>(opinion));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SaveOpinionResource resource)
        {
            var opinion = repository.Get(id);

            if (opinion == null)
                return NotFound();

            mapper.Map<SaveOpinionResource, Opinion>(resource, opinion);
            opinion.LastEditTime = DateTime.Now;
            unitOfWork.Complete();

            return Ok(mapper.Map<Opinion, ReadOpinionResource>(opinion)); ;
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<SaveOpinionResource> resourcePatch)
        {
            var opinion = repository.Get(id);

            if (opinion == null)
                return NotFound();

            var resource = mapper.Map<Opinion, SaveOpinionResource>(opinion);
            resourcePatch.ApplyTo(resource);
            mapper.Map<SaveOpinionResource, Opinion>(resource, opinion);
            
            opinion.LastEditTime = DateTime.Now;

            unitOfWork.Complete();

            return Ok(mapper.Map<Opinion, ReadOpinionResource>(opinion)); ;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var opinion = repository.Get(id);

            if (opinion == null)
                return NotFound();

            repository.Remove(opinion);
            unitOfWork.Complete();

            return Ok(id);
        }
    }
}