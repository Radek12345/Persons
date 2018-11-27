using System;

namespace Persons.Controllers.Resources
{
    public class SavePersonResource
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public int CompanyBranchId { get; set; }
        public int CityId { get; set; }
    }
}
