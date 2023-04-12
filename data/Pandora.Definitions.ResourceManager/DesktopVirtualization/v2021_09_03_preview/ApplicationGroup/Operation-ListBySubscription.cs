using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.ApplicationGroup;

internal class ListBySubscriptionOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(ApplicationGroupModel);

    public override Type? OptionsObject() => typeof(ListBySubscriptionOperation.ListBySubscriptionOptions);

    public override string? UriSuffix() => "/providers/Microsoft.DesktopVirtualization/applicationGroups";

    internal class ListBySubscriptionOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
