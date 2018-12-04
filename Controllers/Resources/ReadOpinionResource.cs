using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Persons.Controllers.Resources
{
    public class ReadOpinionResource
    {
        public int Id { get; set; }
        public string OpinionText { get; set; }
        public int Rate { get; set; }
        public string Information { get; set; }
        public ICollection<ReadCommentResource> Comments { get; set; }
        public ReadOpinionResource()
        {
            Comments = new Collection<ReadCommentResource>();
        }
    }
}