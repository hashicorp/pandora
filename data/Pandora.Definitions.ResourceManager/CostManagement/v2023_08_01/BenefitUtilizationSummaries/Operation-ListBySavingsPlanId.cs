using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.BenefitUtilizationSummaries;

internal class ListBySavingsPlanIdOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SavingsPlanId();

    public override Type NestedItemType() => typeof(BenefitUtilizationSummaryModel);

    public override Type? OptionsObject() => typeof(ListBySavingsPlanIdOperation.ListBySavingsPlanIdOptions);

    public override string? UriSuffix() => "/providers/Microsoft.CostManagement/benefitUtilizationSummaries";

    internal class ListBySavingsPlanIdOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("grainParameter")]
        [Optional]
        public GrainParameterConstant GrainParameter { get; set; }
    }
}
