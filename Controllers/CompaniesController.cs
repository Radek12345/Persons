using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persons.Controllers.Resources;
using Persons.Core;
using Persons.Core.Domain;
using Persons.Core.Repositories;

namespace Persons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CompaniesController(ICompanyRepository companyRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ViewCompanyResource>> GetCompanies()
        {
            var companies = await companyRepository.GetCompaniesWithBranchesAsync();
            return mapper.Map<IEnumerable<Company>, IEnumerable<ViewCompanyResource>>(companies);
        }
    }
}