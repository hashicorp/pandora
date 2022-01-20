using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20.CommunicationService
{
    internal class Definition : ResourceDefinition
    {
        public string Name => "CommunicationService";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CheckNameAvailabilityOperation(),
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new LinkNotificationHubOperation(),
            new ListByResourceGroupOperation(),
            new ListBySubscriptionOperation(),
            new ListKeysOperation(),
            new RegenerateKeyOperation(),
            new UpdateOperation(),
        };
    }
}
