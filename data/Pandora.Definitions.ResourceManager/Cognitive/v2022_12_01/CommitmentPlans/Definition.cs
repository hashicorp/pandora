using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CommitmentPlans;

internal class Definition : ResourceDefinition
{
    public string Name => "CommitmentPlans";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateOrUpdateAssociationOperation(),
        new DeleteOperation(),
        new DeleteAssociationOperation(),
        new GetOperation(),
        new GetAssociationOperation(),
        new ListOperation(),
        new ListAssociationsOperation(),
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
        typeof(CommitmentPlanAccountAssociationModel),
        typeof(CommitmentPlanAccountAssociationPropertiesModel),
        typeof(CommitmentPlanPropertiesModel),
        typeof(CommitmentQuotaModel),
        typeof(SkuModel),
    };
}
