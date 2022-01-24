using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new TrafficManagerProfileId();

    public override Type? ResponseObject() => typeof(ProfileModel);


}
