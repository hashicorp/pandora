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
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new BillingAccountId();

\t\tpublic override Type NestedItemType() => typeof(BenefitUtilizationSummaryModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByBillingAccountIdOperation.ListByBillingAccountIdOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.CostManagement/benefitUtilizationSummaries";

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
