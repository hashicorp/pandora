using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateLinkResources
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "fd7603f9a8acb1decf94f7770a0bfe7b78df9b20" 

        public string ApiVersion => "2020-06-01";
        public string Name => "PrivateLinkResources";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new GetOperation(),
            new ListByConfigurationStoreOperation(),
        };
    }
}
