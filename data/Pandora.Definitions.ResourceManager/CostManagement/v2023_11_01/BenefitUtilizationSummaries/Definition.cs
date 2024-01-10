using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_11_01.BenefitUtilizationSummaries;

internal class Definition : ResourceDefinition
{
    public string Name => "BenefitUtilizationSummaries";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByBillingAccountIdOperation(),
        new ListByBillingProfileIdOperation(),
        new ListBySavingsPlanIdOperation(),
        new ListBySavingsPlanOrderOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BenefitKindConstant),
        typeof(GrainParameterConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BenefitUtilizationSummaryModel),
        typeof(IncludedQuantityUtilizationSummaryModel),
        typeof(IncludedQuantityUtilizationSummaryPropertiesModel),
        typeof(SavingsPlanUtilizationSummaryModel),
        typeof(SavingsPlanUtilizationSummaryPropertiesModel),
    };
}
