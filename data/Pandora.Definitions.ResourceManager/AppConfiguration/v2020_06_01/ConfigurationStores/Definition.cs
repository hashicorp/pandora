using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "9593dd087d60017b83cfc590ffea5d7374a3f734" 

        public string ApiVersion => "2020-06-01";
        public string Name => "ConfigurationStores";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListOperation(),
            new ListByResourceGroupOperation(),
            new ListKeyValueOperation(),
            new ListKeysOperation(),
            new RegenerateKeyOperation(),
            new UpdateOperation(),
        };
    }
}
