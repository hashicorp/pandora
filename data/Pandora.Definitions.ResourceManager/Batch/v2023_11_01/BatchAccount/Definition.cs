using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_11_01.BatchAccount;

internal class Definition : ResourceDefinition
{
    public string Name => "BatchAccount";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetKeysOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListOutboundNetworkDependenciesEndpointsOperation(),
        new RegenerateKeyOperation(),
        new SynchronizeAutoStorageKeysOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccountKeyTypeConstant),
        typeof(AuthenticationModeConstant),
        typeof(AutoStorageAuthenticationModeConstant),
        typeof(EndpointAccessDefaultActionConstant),
        typeof(IPRuleActionConstant),
        typeof(KeySourceConstant),
        typeof(PoolAllocationModeConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateLinkServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoStorageBasePropertiesModel),
        typeof(AutoStoragePropertiesModel),
        typeof(BatchAccountModel),
        typeof(BatchAccountCreateParametersModel),
        typeof(BatchAccountCreatePropertiesModel),
        typeof(BatchAccountKeysModel),
        typeof(BatchAccountPropertiesModel),
        typeof(BatchAccountRegenerateKeyParametersModel),
        typeof(BatchAccountUpdateParametersModel),
        typeof(BatchAccountUpdatePropertiesModel),
        typeof(ComputeNodeIdentityReferenceModel),
        typeof(EncryptionPropertiesModel),
        typeof(EndpointAccessProfileModel),
        typeof(EndpointDependencyModel),
        typeof(EndpointDetailModel),
        typeof(IPRuleModel),
        typeof(KeyVaultPropertiesModel),
        typeof(KeyVaultReferenceModel),
        typeof(NetworkProfileModel),
        typeof(OutboundEnvironmentEndpointModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(VirtualMachineFamilyCoreQuotaModel),
    };
}
