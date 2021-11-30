using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerNamespaces
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2020-10-15-preview";
        public string Name => "PartnerNamespaces";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new ListByResourceGroupOperation(),
            new ListBySubscriptionOperation(),
            new ListSharedAccessKeysOperation(),
            new RegenerateKeyOperation(),
            new UpdateOperation(),
        };
    }
}
