using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.Account
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "b2bddfe2e59b5b14e559e0433b6e6d057bcff95d" 

        public string ApiVersion => "2020-12-01-preview";
        public string Name => "Account";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByResourceGroupOperation(),
            new ListBySubscriptionOperation(),
            new ListKeysOperation(),
            new UpdateOperation(),
        };
    }
}
