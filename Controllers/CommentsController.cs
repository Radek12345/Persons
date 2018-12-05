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
    [Route("/api/comments")]
    public class CommentsController : AbstractReadOnlyRestController<IRepository<Comment>, Comment,
        ReadCommentResource>
    {
        public CommentsController(IRepository<Comment> repository, IMapper mapper, IUnitOfWork unitOfWork) 
            : base(repository, mapper, unitOfWork)
        {
        }

        [HttpPost]
        public IActionResult Create([FromBody] SaveCommentResource resource)
        {
            var comment = mapper.Map<SaveCommentResource, Comment>(resource);
            
            comment.AdditionTime = DateTime.Now;
            repository.Add(comment);
            unitOfWork.Complete();

            return Ok(mapper.Map<Comment, ReadCommentResource>(comment));
        }
    }
}