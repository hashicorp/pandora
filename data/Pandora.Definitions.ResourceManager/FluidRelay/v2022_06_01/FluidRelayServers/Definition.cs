using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.FluidRelay.v2022_06_01.FluidRelayServers;

internal class Definition : ResourceDefinition
{
    public string Name => "FluidRelayServers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new RegenerateKeyOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CmkIdentityTypeConstant),
        typeof(KeyNameConstant),
        typeof(ProvisioningStateConstant),
        typeof(StorageSKUConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CustomerManagedKeyEncryptionPropertiesModel),
        typeof(CustomerManagedKeyEncryptionPropertiesKeyEncryptionKeyIdentityModel),
        typeof(EncryptionPropertiesModel),
        typeof(FluidRelayEndpointsModel),
        typeof(FluidRelayServerModel),
        typeof(FluidRelayServerKeysModel),
        typeof(FluidRelayServerPropertiesModel),
        typeof(FluidRelayServerUpdateModel),
        typeof(FluidRelayServerUpdatePropertiesModel),
        typeof(RegenerateKeyRequestModel),
    };
}
