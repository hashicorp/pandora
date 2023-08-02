using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceProviders;

internal class ListBillingMetersOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(BillingMeterModel);

    public override Type? OptionsObject() => typeof(ListBillingMetersOperation.ListBillingMetersOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Web/billingMeters";

    internal class ListBillingMetersOptions
    {
        [QueryStringName("billingLocation")]
        [Optional]
        public string BillingLocation { get; set; }

        [QueryStringName("osType")]
        [Optional]
        public string OsType { get; set; }
    }
}
