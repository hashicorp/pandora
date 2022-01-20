using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateLinkResources;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new PrivateLinkResourceId();

    public override Type? ResponseObject() => typeof(PrivateLinkResourceModel);


}
