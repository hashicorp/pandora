using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Locations;

internal class GetCapabilityOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(CapabilityInformationModel);

    public override string? UriSuffix() => "/capability";


}
