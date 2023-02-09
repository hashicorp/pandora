using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.ShareSubscription;

internal class ConsumerSourceDataSetsListByShareSubscriptionOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ShareSubscriptionId();

    public override Type NestedItemType() => typeof(ConsumerSourceDataSetModel);

    public override string? UriSuffix() => "/consumerSourceDataSets";


}
