using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Namespaces
{
    internal class UpdateOperation : Operations.PatchOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.Accepted,
                HttpStatusCode.Created,
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(EHNamespaceModel);
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override Type? ResponseObject()
        {
            return typeof(EHNamespaceModel);
        }


    }
}
