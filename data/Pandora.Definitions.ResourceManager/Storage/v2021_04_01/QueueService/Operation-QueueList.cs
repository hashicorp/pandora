using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.QueueService;

internal class QueueListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new StorageAccountId();

    public override Type NestedItemType() => typeof(ListQueueModel);

    public override Type? OptionsObject() => typeof(QueueListOperation.QueueListOptions);

    public override string? UriSuffix() => "/queueServices/default/queues";

    internal class QueueListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$maxpagesize")]
        [Optional]
        public string Maxpagesize { get; set; }
    }
}
