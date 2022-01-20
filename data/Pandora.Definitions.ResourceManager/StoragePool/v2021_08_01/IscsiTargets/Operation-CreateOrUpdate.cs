using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.IscsiTargets;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(IscsiTargetCreateModel);

    public override ResourceID? ResourceId() => new IscsiTargetId();

    public override Type? ResponseObject() => typeof(IscsiTargetModel);


}
