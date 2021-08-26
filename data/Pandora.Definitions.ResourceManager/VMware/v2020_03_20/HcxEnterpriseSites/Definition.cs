using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.HcxEnterpriseSites
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "5844fecb75c31a578ab2548caa8524e6126b0520" 

        public string ApiVersion => "2020-03-20";
        public string Name => "HcxEnterpriseSites";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
        };
    }
}
