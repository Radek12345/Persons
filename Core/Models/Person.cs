using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.Core.Models
{
    [Table("Persons")]
    public class Person
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string LastName { get; set; }

        [StringLength(255)]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "Date")]
        [Required]
        public DateTime BirthDate { get; set; }

        public CompanyBranch CompanyBranch { get; set; }

        public int CompanyBranchId { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }
    }
}
