using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{
    internal class SystemTopicEventSubscriptionsGetDeliveryAttributesOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

        public override Type? RequestObject() => null;

        public override ResourceID? ResourceId() => new EventSubscriptionId();

        public override Type? ResponseObject() => typeof(DeliveryAttributeListResultModel);

        public override string? UriSuffix() => "/getDeliveryAttributes";


    }
}
