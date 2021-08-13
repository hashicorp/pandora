using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces
{
    internal class UpdateOperation : Operations.PatchOperation
    {
        public override Type? RequestObject()
        {
            return typeof(RelayUpdateParametersModel);
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override Type? ResponseObject()
        {
            return typeof(RelayNamespaceModel);
        }


    }
}
