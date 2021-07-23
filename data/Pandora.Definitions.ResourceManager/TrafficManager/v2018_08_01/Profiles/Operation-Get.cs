using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{
    internal class Get : GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new TrafficmanagerprofileId();
        }

        public override object? ResponseObject()
        {
            return new Profile();
        }


    }
}
