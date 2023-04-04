using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2021_08_01.Vaults;

internal class Definition : ResourceDefinition
{
    public string Name => "Vaults";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionIdOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(InfrastructureEncryptionStateConstant),
        typeof(PrivateEndpointConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(ResourceMoveStateConstant),
        typeof(SkuNameConstant),
        typeof(TriggerTypeConstant),
        typeof(VaultPrivateEndpointStateConstant),
        typeof(VaultUpgradeStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CmkKekIdentityModel),
        typeof(CmkKeyVaultPropertiesModel),
        typeof(PatchVaultModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionVaultPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(SkuModel),
        typeof(UpgradeDetailsModel),
        typeof(VaultModel),
        typeof(VaultPropertiesModel),
        typeof(VaultPropertiesEncryptionModel),
        typeof(VaultPropertiesMoveDetailsModel),
    };
}
