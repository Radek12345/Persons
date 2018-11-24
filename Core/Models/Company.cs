using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Persons.Core.Models
{
    public class Company
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<CompanyBranch> CompanyBranches { get; set; }

        public Company()
        {
            CompanyBranches = new Collection<CompanyBranch>();
        }
    }
}
