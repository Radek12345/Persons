using AutoMapper;
using Persons.Controllers.Abstract;
using Persons.Controllers.Resources;
using Persons.Core;
using Persons.Core.Domain;
using Persons.Core.Repositories;

namespace Persons.Controllers
{
    public class OpinionsController : AbstractReadOnlyRestController<IRepository<Opinion>, Opinion,
        ReadOpinionResource>
    {
        public OpinionsController(IRepository<Opinion> repository, IMapper mapper, IUnitOfWork unitOfWork) 
            : base(repository, mapper, unitOfWork)
        {
        }
    }
}