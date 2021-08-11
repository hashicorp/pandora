using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateEndpointConnections
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new PrivateEndpointConnectionId();
        }

        public override object? ResponseObject()
        {
            return new PrivateEndpointConnectionModel();
        }


    }
}
