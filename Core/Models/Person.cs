using System;
using System.ComponentModel.DataAnnotations;

namespace Persons.Core.Models
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public CompanyBranch CompanyBranch { get; set; }

        public int CompanyBranchId { get; set; }
    }
}
