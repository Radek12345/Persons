using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.Core.Models
{
    [Table("CompanyBranches")]
    public class CompanyBranch
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
