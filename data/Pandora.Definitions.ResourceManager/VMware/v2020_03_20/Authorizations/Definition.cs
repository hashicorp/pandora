using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Authorizations
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "d23ad89e8c3e98c4f941fd9ec3db6ab39951a494" 

        public string ApiVersion => "2020-03-20";
        public string Name => "Authorizations";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
        };
    }
}
