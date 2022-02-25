using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.RedisEnterprise;

internal class CreateOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ClusterModel);

    public override ResourceID? ResourceId() => new RedisEnterpriseId();

    public override Type? ResponseObject() => typeof(ClusterModel);


}
