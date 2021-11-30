using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Topics
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2020-10-15-preview";
        public string Name => "Topics";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new ExtensionTopicsGetOperation(),
            new GetOperation(),
            new ListByResourceGroupOperation(),
            new ListBySubscriptionOperation(),
            new ListEventTypesOperation(),
            new ListSharedAccessKeysOperation(),
            new RegenerateKeyOperation(),
            new UpdateOperation(),
        };
    }
}
