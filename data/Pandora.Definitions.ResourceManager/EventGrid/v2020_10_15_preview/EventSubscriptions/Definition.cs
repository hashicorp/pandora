using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2020-10-15-preview";
        public string Name => "EventSubscriptions";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new CreateOrUpdateOperation(),
            new DeleteOperation(),
            new GetOperation(),
            new GetDeliveryAttributesOperation(),
            new GetFullUrlOperation(),
            new ListByDomainTopicOperation(),
            new ListByResourceOperation(),
            new ListGlobalByResourceGroupOperation(),
            new ListGlobalByResourceGroupForTopicTypeOperation(),
            new ListGlobalBySubscriptionOperation(),
            new ListGlobalBySubscriptionForTopicTypeOperation(),
            new ListRegionalByResourceGroupOperation(),
            new ListRegionalByResourceGroupForTopicTypeOperation(),
            new ListRegionalBySubscriptionOperation(),
            new ListRegionalBySubscriptionForTopicTypeOperation(),
            new PartnerTopicEventSubscriptionsCreateOrUpdateOperation(),
            new PartnerTopicEventSubscriptionsDeleteOperation(),
            new PartnerTopicEventSubscriptionsGetOperation(),
            new PartnerTopicEventSubscriptionsGetDeliveryAttributesOperation(),
            new PartnerTopicEventSubscriptionsGetFullUrlOperation(),
            new PartnerTopicEventSubscriptionsListByPartnerTopicOperation(),
            new PartnerTopicEventSubscriptionsUpdateOperation(),
            new SystemTopicEventSubscriptionsCreateOrUpdateOperation(),
            new SystemTopicEventSubscriptionsDeleteOperation(),
            new SystemTopicEventSubscriptionsGetOperation(),
            new SystemTopicEventSubscriptionsGetDeliveryAttributesOperation(),
            new SystemTopicEventSubscriptionsGetFullUrlOperation(),
            new SystemTopicEventSubscriptionsListBySystemTopicOperation(),
            new SystemTopicEventSubscriptionsUpdateOperation(),
            new UpdateOperation(),
        };
    }
}
