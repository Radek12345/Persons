using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Controllers.Abstract;
using Persons.Controllers.Resources;
using Persons.Core;
using Persons.Core.Domain;
using Persons.Core.Repositories;

namespace Persons.Controllers
{
    [Route("/api/opinions")]
    public class OpinionsController : AbstractReadOnlyRestController<IRepository<Opinion>, Opinion,
        ReadOpinionResource>
    {
        public OpinionsController(IRepository<Opinion> repository, IMapper mapper, IUnitOfWork unitOfWork) 
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