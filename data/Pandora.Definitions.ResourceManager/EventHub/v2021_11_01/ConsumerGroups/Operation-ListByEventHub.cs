using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.ConsumerGroups;

internal class ListByEventHubOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new EventhubId();

\t\tpublic override Type NestedItemType() => typeof(ConsumerGroupModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByEventHubOperation.ListByEventHubOptions);

\t\tpublic override string? UriSuffix() => "/consumerGroups";

    internal class ListByEventHubOptions
    {
        [QueryStringName("$skip")]
        [Optional]
        public int Skip { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
