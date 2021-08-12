using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.PrivateEndpointConnections
{
    internal class ListOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new AttestationProviderId();
        }

        public override object? ResponseObject()
        {
            return new PrivateEndpointConnectionListResultModel();
        }

        public override string? UriSuffix()
        {
            return "/privateEndpointConnections";
        }


    }
}
