using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.Core.Domain
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string CommentText { get; set; }

        [Required]
        public DateTime AdditionTime { get; set; }

        public int CommentId { get; set; }
    }
}