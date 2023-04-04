using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Vaults;

internal class Definition : ResourceDefinition
{
    public string Name => "Vaults";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetDeletedOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListDeletedOperation(),
        new PurgeDeletedOperation(),
        new UpdateOperation(),
        new UpdateAccessPolicyOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessPolicyUpdateKindConstant),
        typeof(ActionsRequiredConstant),
        typeof(CertificatePermissionsConstant),
        typeof(CreateModeConstant),
        typeof(KeyPermissionsConstant),
        typeof(NetworkRuleActionConstant),
        typeof(NetworkRuleBypassOptionsConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ReasonConstant),
        typeof(SecretPermissionsConstant),
        typeof(SkuFamilyConstant),
        typeof(SkuNameConstant),
        typeof(StoragePermissionsConstant),
        typeof(TypeConstant),
        typeof(VaultListFilterTypesConstant),
        typeof(VaultProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessPolicyEntryModel),
        typeof(CheckNameAvailabilityResultModel),
        typeof(DeletedVaultModel),
        typeof(DeletedVaultPropertiesModel),
        typeof(IPRuleModel),
        typeof(NetworkRuleSetModel),
        typeof(PermissionsModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionItemModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(ResourceModel),
        typeof(SkuModel),
        typeof(VaultModel),
        typeof(VaultAccessPolicyParametersModel),
        typeof(VaultAccessPolicyPropertiesModel),
        typeof(VaultCheckNameAvailabilityParametersModel),
        typeof(VaultCreateOrUpdateParametersModel),
        typeof(VaultPatchParametersModel),
        typeof(VaultPatchPropertiesModel),
        typeof(VaultPropertiesModel),
        typeof(VirtualNetworkRuleModel),
    };
}
