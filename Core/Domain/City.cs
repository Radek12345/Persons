using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.Core.Domain
{
    [Table("Cities")]
    public class City
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
