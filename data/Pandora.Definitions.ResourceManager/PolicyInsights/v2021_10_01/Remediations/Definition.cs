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
        new RemediationsCancelAtManagementGroupOperation(),
        new RemediationsCancelAtResourceOperation(),
        new RemediationsCancelAtResourceGroupOperation(),
        new RemediationsCancelAtSubscriptionOperation(),
        new RemediationsCreateOrUpdateAtManagementGroupOperation(),
        new RemediationsCreateOrUpdateAtResourceOperation(),
        new RemediationsCreateOrUpdateAtResourceGroupOperation(),
        new RemediationsCreateOrUpdateAtSubscriptionOperation(),
        new RemediationsDeleteAtManagementGroupOperation(),
        new RemediationsDeleteAtResourceOperation(),
        new RemediationsDeleteAtResourceGroupOperation(),
        new RemediationsDeleteAtSubscriptionOperation(),
        new RemediationsGetAtManagementGroupOperation(),
        new RemediationsGetAtResourceOperation(),
        new RemediationsGetAtResourceGroupOperation(),
        new RemediationsGetAtSubscriptionOperation(),
        new RemediationsListDeploymentsAtManagementGroupOperation(),
        new RemediationsListDeploymentsAtResourceOperation(),
        new RemediationsListDeploymentsAtResourceGroupOperation(),
        new RemediationsListDeploymentsAtSubscriptionOperation(),
        new RemediationsListForManagementGroupOperation(),
        new RemediationsListForResourceOperation(),
        new RemediationsListForResourceGroupOperation(),
        new RemediationsListForSubscriptionOperation(),
    };
}
