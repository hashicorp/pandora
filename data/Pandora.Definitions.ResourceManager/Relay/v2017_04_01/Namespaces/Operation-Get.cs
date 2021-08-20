using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new NamespaceId();

        public override Type? ResponseObject() => typeof(RelayNamespaceModel);


    }
}
