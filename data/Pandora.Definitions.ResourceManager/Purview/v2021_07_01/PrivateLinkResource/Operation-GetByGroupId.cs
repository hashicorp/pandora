using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.PrivateLinkResource
{
    internal class GetByGroupIdOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new PrivateLinkResourceId();
        }

        public override Type? ResponseObject()
        {
            return typeof(PrivateLinkResourceModel);
        }


    }
}
