using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01.VolumeGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "VolumeGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByElasticSanOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionConstant),
        typeof(EncryptionTypeConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(ProvisioningStatesConstant),
        typeof(StorageTargetTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EncryptionIdentityModel),
        typeof(EncryptionPropertiesModel),
        typeof(KeyVaultPropertiesModel),
        typeof(NetworkRuleSetModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(VirtualNetworkRuleModel),
        typeof(VolumeGroupModel),
        typeof(VolumeGroupPropertiesModel),
        typeof(VolumeGroupUpdateModel),
        typeof(VolumeGroupUpdatePropertiesModel),
    };
}
