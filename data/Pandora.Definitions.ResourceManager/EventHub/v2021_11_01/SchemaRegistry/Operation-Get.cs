using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.SchemaRegistry;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SchemagroupId();

    public override Type? ResponseObject() => typeof(SchemaGroupModel);


}
