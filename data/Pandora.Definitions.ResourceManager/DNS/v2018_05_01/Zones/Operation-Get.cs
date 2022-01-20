using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.Zones;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new DnsZoneId();

    public override Type? ResponseObject() => typeof(ZoneModel);


}
