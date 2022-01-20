using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.Servers;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ServerId();

    public override Type? ResponseObject() => typeof(ServerGroupServerModel);


}
