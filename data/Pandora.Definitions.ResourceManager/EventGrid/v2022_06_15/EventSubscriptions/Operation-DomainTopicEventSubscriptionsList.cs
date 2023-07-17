using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.EventSubscriptions;

internal class DomainTopicEventSubscriptionsListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new DomainTopicId();

    public override Type NestedItemType() => typeof(EventSubscriptionModel);

    public override Type? OptionsObject() => typeof(DomainTopicEventSubscriptionsListOperation.DomainTopicEventSubscriptionsListOptions);

    public override string? UriSuffix() => "/eventSubscriptions";

    internal class DomainTopicEventSubscriptionsListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
