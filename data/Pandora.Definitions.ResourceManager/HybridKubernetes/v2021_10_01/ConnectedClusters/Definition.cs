using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.ConnectedClusters;

internal class Definition : ResourceDefinition
{
    public string Name => "ConnectedClusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConnectedClusterCreateOperation(),
        new ConnectedClusterDeleteOperation(),
        new ConnectedClusterGetOperation(),
        new ConnectedClusterListByResourceGroupOperation(),
        new ConnectedClusterListBySubscriptionOperation(),
        new ConnectedClusterListClusterUserCredentialOperation(),
        new ConnectedClusterUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthenticationMethodConstant),
        typeof(ConnectivityStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectedClusterModel),
        typeof(ConnectedClusterPatchModel),
        typeof(ConnectedClusterPropertiesModel),
        typeof(CredentialResultModel),
        typeof(CredentialResultsModel),
        typeof(HybridConnectionConfigModel),
        typeof(ListClusterUserCredentialPropertiesModel),
    };
}
