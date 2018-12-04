using AutoMapper;
using Persons.Controllers.Resources;
using Persons.Core.Domain;
using System;

namespace Persons.Mapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Person, ReadPersonResource>()
                .ForMember(rpr => rpr.Age, opt => opt.MapFrom(p => CalculateAge(p.BirthDate)))
                .ForMember(rpr => rpr.Sex, opt => opt.MapFrom(p => CheckGender(p.FirstName)))
                .ForMember(rpr => rpr.City, opt => opt.MapFrom(p => p.City.Name))
                .ForMember(rpr => rpr.Company, opt => opt.MapFrom(p => p.CompanyBranch.Company.Name))
                .ForMember(rpr => rpr.CompanyId, opt => opt.MapFrom(p => p.CompanyBranch.Company.Id))
                .ForMember(rpr => rpr.CompanyBranch, opt => opt.MapFrom(p => p.CompanyBranch.Name));

            CreateMap<SavePersonResource, Person>();
            CreateMap<City, KeyValuePairResource>();
            CreateMap<Company, ReadCompanyResource>();
            CreateMap<SaveOpinionResource, Opinion>();
            CreateMap<Opinion, ReadOpinionResource>();
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
                return --age;

            return age;
        }

        private char CheckGender(string firstName)
        {
            return firstName[firstName.Length - 1] == 'a' ? 'K' : 'M';
        }
    }
}
