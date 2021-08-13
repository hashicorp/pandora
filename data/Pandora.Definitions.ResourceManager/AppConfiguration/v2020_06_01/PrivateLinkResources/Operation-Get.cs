using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateLinkResources
{
    internal class GetOperation : Operations.GetOperation
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
