using System.ComponentModel.DataAnnotations;

namespace Persons.Controllers.Resources
{
    public class SaveCommentResource
    {
        [Required]
        public string CommentText { get; set; }

        [Required]
        public int OpinionId { get; set; }
    }
}