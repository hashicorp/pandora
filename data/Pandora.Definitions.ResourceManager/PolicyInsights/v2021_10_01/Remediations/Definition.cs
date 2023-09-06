using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2021_10_01.Remediations;

internal class Definition : ResourceDefinition
{
    public string Name => "Remediations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelAtManagementGroupOperation(),
        new CancelAtResourceOperation(),
        new CancelAtResourceGroupOperation(),
        new CancelAtSubscriptionOperation(),
        new CreateOrUpdateAtManagementGroupOperation(),
        new CreateOrUpdateAtResourceOperation(),
        new CreateOrUpdateAtResourceGroupOperation(),
        new CreateOrUpdateAtSubscriptionOperation(),
        new DeleteAtManagementGroupOperation(),
        new DeleteAtResourceOperation(),
        new DeleteAtResourceGroupOperation(),
        new DeleteAtSubscriptionOperation(),
        new GetAtManagementGroupOperation(),
        new GetAtResourceOperation(),
        new GetAtResourceGroupOperation(),
        new GetAtSubscriptionOperation(),
        new ListDeploymentsAtManagementGroupOperation(),
        new ListDeploymentsAtResourceOperation(),
        new ListDeploymentsAtResourceGroupOperation(),
        new ListDeploymentsAtSubscriptionOperation(),
        new ListForManagementGroupOperation(),
        new ListForResourceOperation(),
        new ListForResourceGroupOperation(),
        new ListForSubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ResourceDiscoveryModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ErrorDefinitionModel),
        typeof(RemediationModel),
        typeof(RemediationDeploymentModel),
        typeof(RemediationDeploymentSummaryModel),
        typeof(RemediationFiltersModel),
        typeof(RemediationPropertiesModel),
        typeof(RemediationPropertiesFailureThresholdModel),
        typeof(TypedErrorInfoModel),
    };
}
