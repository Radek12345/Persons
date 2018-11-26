using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
