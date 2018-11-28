using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Persons.Controllers.Abstract;
using Persons.Controllers.Resources;
using Persons.Core;
using Persons.Core.Domain;
using Persons.Core.Repositories;

namespace Persons.Controllers
{
    [Route("/api/companies")]
    public class CompaniesController : AbstractReadOnlyRestController<ICompanyRepository, Company, ReadCompanyResource>
    {
        public CompaniesController(ICompanyRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
            : base(repository, mapper, unitOfWork) { }
    }
}