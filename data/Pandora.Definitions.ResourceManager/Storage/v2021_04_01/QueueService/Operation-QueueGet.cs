using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.QueueService;

internal class QueueGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new QueueId();

    public override Type? ResponseObject() => typeof(StorageQueueModel);


}
