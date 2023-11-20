using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.ConsumerGroups;

internal class ListByEventHubOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new EventhubId();

    public override Type NestedItemType() => typeof(ConsumerGroupModel);

    public override Type? OptionsObject() => typeof(ListByEventHubOperation.ListByEventHubOptions);

    public override string? UriSuffix() => "/consumerGroups";

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
