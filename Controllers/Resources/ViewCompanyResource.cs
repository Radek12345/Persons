using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Controllers.Resources
{
    public class ViewCompanyResource : KeyValuePairResource
    {
        public ICollection<KeyValuePairResource> Branches { get; set; }

        public ViewCompanyResource()
        {
            Branches = new Collection<KeyValuePairResource>();
        }
    }
}
