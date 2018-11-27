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
            CreateMap<Person, ViewPersonResource>()
                .ForMember(vpr => vpr.Age, opt => opt.MapFrom(p => CalculateAge(p.BirthDate)))
                .ForMember(vpr => vpr.Sex, opt => opt.MapFrom(p => CheckGender(p.FirstName)))
                .ForMember(vpr => vpr.City, opt => opt.MapFrom(p => p.City.Name))
                .ForMember(vpr => vpr.Company, opt => opt.MapFrom(p => p.CompanyBranch.Company.Name))
                .ForMember(vpr => vpr.CompanyBranch, opt => opt.MapFrom(p => p.CompanyBranch.Name));

            CreateMap<SavePersonResource, Person>();
            CreateMap<City, SimpleTextResource>();
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
