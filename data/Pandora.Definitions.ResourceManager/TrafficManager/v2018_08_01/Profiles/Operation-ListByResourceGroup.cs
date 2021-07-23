using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{
    internal class ListByResourceGroup : GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new ResourceGroupId();
        }

        public override object? ResponseObject()
        {
            return new ProfileListResult();
        }

        public override string? UriSuffix()
        {
            return "/providers/Microsoft.Network/trafficmanagerprofiles";
        }


    }
}
