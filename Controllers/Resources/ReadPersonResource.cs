using System;

namespace Persons.Controllers.Resources
{
    public class ReadPersonResource
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public byte Age { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
        public string Company { get; set; }
        public int CompanyId { get; set; }
        public string CompanyBranch { get; set; }
        public int CompanyBranchId { get; set; }
        public string City { get; set; }
        public int CityId { get; set; }
    }
}
