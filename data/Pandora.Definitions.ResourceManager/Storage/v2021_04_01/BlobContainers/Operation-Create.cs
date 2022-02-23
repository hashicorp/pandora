using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;

internal class CreateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(BlobContainerModel);

    public override ResourceID? ResourceId() => new ContainerId();

    public override Type? ResponseObject() => typeof(BlobContainerModel);


}
