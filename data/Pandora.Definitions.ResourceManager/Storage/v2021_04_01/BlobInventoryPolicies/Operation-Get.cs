using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobInventoryPolicies;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new BlobInventoryPolicyId();

    public override Type? ResponseObject() => typeof(BlobInventoryPolicyModel);


}
