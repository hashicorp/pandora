using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.ApplicationDefinitions;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationDefinitions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApplicationArtifactTypeConstant),
        typeof(ApplicationDefinitionArtifactNameConstant),
        typeof(ApplicationLockLevelConstant),
        typeof(ApplicationManagementModeConstant),
        typeof(DeploymentModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationAuthorizationModel),
        typeof(ApplicationDefinitionModel),
        typeof(ApplicationDefinitionArtifactModel),
        typeof(ApplicationDefinitionPatchableModel),
        typeof(ApplicationDefinitionPropertiesModel),
        typeof(ApplicationDeploymentPolicyModel),
        typeof(ApplicationManagementPolicyModel),
        typeof(ApplicationNotificationEndpointModel),
        typeof(ApplicationNotificationPolicyModel),
        typeof(ApplicationPackageLockingPolicyDefinitionModel),
        typeof(ApplicationPolicyModel),
        typeof(SkuModel),
    };
}
