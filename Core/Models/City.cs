using System.ComponentModel.DataAnnotations;

namespace Persons.Core.Models
{
    public class City
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}
