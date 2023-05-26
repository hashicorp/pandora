using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2023_05_01.CognitiveServicesCommitmentPlans;

internal class Definition : ResourceDefinition
{
    public string Name => "CognitiveServicesCommitmentPlans";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CommitmentPlansCreateOrUpdatePlanOperation(),
        new CommitmentPlansDeletePlanOperation(),
        new CommitmentPlansGetPlanOperation(),
        new CommitmentPlansListPlansByResourceGroupOperation(),
        new CommitmentPlansListPlansBySubscriptionOperation(),
        new CommitmentPlansUpdatePlanOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CommitmentPlanProvisioningStateConstant),
        typeof(HostingModelConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CommitmentPeriodModel),
        typeof(CommitmentPlanModel),
        typeof(CommitmentPlanPropertiesModel),
        typeof(CommitmentQuotaModel),
        typeof(PatchResourceTagsAndSkuModel),
        typeof(SkuModel),
    };
}
