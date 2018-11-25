using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.Core.Models
{
    [Table("Companies")]
    public class Company
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public ICollection<CompanyBranch> Branches { get; set; }

        public Company()
        {
            Branches = new Collection<CompanyBranch>();
        }
    }
}
