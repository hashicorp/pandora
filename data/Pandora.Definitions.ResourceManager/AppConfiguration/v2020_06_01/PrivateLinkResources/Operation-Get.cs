using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateLinkResources
{
    internal class Get : GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new PrivateLinkResourceId();
        }

        public override object? ResponseObject()
        {
            return new PrivateLinkResource();
        }
    }
}
