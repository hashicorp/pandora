using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.AttestationProviders
{
    internal class ListOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new SubscriptionId();

        public override Type? ResponseObject() => typeof(AttestationProviderListResultModel);

        public override string? UriSuffix() => "/providers/Microsoft.Attestation/attestationProviders";


    }
}
