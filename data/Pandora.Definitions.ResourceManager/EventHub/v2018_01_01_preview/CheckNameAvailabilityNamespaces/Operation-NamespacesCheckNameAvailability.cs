using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.CheckNameAvailabilityNamespaces
{
    internal class NamespacesCheckNameAvailabilityOperation : Operations.PostOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(CheckNameAvailabilityParameterModel);
        }

        public override ResourceID? ResourceId()
        {
            return new SubscriptionId();
        }

        public override Type? ResponseObject()
        {
            return typeof(CheckNameAvailabilityResultModel);
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.EventHub/checkNameAvailability";
        }


    }
}
