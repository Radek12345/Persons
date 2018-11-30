using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.Core.Domain
{
    [Table("Opinions")]
    public class Opinion
    {
        public int Id { get; set; }

        [Required]
        public string OpinionText { get; set; }

        public int Rate { get; set; }

        [StringLength(255)]
        [Required]
        public string information { get; set; }

        [Required]
        public DateTime AdditionTime { get; set; }

        [Required]
        public DateTime LastEditTime { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Opinion()
        {
            Comments = new Collection<Comment>();
        }
    }
}