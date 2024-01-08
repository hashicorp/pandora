using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_09_01.NetworkManagers;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkManagers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListBySubscriptionOperation(),
        new NetworkManagerCommitsPostOperation(),
        new NetworkManagerDeploymentStatusListOperation(),
        new PatchOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConfigurationTypeConstant),
        typeof(DeploymentStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CrossTenantScopesModel),
        typeof(NetworkManagerModel),
        typeof(NetworkManagerCommitModel),
        typeof(NetworkManagerDeploymentStatusModel),
        typeof(NetworkManagerDeploymentStatusListResultModel),
        typeof(NetworkManagerDeploymentStatusParameterModel),
        typeof(NetworkManagerPropertiesModel),
        typeof(NetworkManagerPropertiesNetworkManagerScopesModel),
        typeof(PatchObjectModel),
    };
}
