using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.CostAllocationRules;

internal class Definition : ResourceDefinition
{
    public string Name => "CostAllocationRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CostAllocationPolicyTypeConstant),
        typeof(CostAllocationResourceTypeConstant),
        typeof(ReasonConstant),
        typeof(RuleStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CostAllocationProportionModel),
        typeof(CostAllocationRuleCheckNameAvailabilityRequestModel),
        typeof(CostAllocationRuleCheckNameAvailabilityResponseModel),
        typeof(CostAllocationRuleDefinitionModel),
        typeof(CostAllocationRuleDetailsModel),
        typeof(CostAllocationRulePropertiesModel),
        typeof(SourceCostAllocationResourceModel),
        typeof(TargetCostAllocationResourceModel),
    };
}
