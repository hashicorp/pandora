using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.BenefitRecommendations;

internal class Definition : ResourceDefinition
{
    public string Name => "BenefitRecommendations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BenefitKindConstant),
        typeof(ExternalCloudProviderTypeConstant),
        typeof(GrainConstant),
        typeof(LookBackPeriodConstant),
        typeof(ScopeConstant),
        typeof(TermConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AllSavingsBenefitDetailsModel),
        typeof(AllSavingsListModel),
        typeof(BenefitRecommendationModelModel),
        typeof(BenefitRecommendationPropertiesModel),
        typeof(RecommendationUsageDetailsModel),
        typeof(SharedScopeBenefitRecommendationPropertiesModel),
        typeof(SingleScopeBenefitRecommendationPropertiesModel),
    };
}
