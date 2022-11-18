using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.BenefitUtilizationSummaries;

internal class ListByBillingAccountIdOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new BillingAccountId();

    public override Type NestedItemType() => typeof(BenefitUtilizationSummaryModel);

    public override Type? OptionsObject() => typeof(ListByBillingAccountIdOperation.ListByBillingAccountIdOptions);

    public override string? UriSuffix() => "/providers/Microsoft.CostManagement/benefitUtilizationSummaries";

    internal class ListByBillingAccountIdOptions
    {
        [QueryStringName("filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("grainParameter")]
        [Optional]
        public GrainParameterConstant GrainParameter { get; set; }
    }
}
