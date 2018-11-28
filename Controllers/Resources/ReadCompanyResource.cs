using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Persons.Controllers.Resources
{
    public class ReadCompanyResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Branches { get; set; }

        public ReadCompanyResource()
        {
            Branches = new Collection<KeyValuePairResource>();
        }
    }
}
