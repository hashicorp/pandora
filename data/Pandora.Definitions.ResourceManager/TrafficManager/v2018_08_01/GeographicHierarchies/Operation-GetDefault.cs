using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.GeographicHierarchies;

internal class GetDefaultOperation : Operations.GetOperation
{
    public override Type? ResponseObject() => typeof(TrafficManagerGeographicHierarchyModel);

    public override string? UriSuffix() => "/providers/Microsoft.Network/trafficManagerGeographicHierarchies/default";


}
