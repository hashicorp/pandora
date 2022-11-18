using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.QueueService;

internal class QueueListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new StorageAccountId();

\t\tpublic override Type NestedItemType() => typeof(ListQueueModel);

\t\tpublic override Type? OptionsObject() => typeof(QueueListOperation.QueueListOptions);

\t\tpublic override string? UriSuffix() => "/queueServices/default/queues";

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
