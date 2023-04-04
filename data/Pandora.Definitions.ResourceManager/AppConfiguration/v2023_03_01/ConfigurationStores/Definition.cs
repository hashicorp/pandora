using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2023_03_01.ConfigurationStores;

internal class Definition : ResourceDefinition
{
    public string Name => "ConfigurationStores";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListKeysOperation(),
        new RegenerateKeyOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionsRequiredConstant),
        typeof(ConnectionStatusConstant),
        typeof(CreateModeConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiKeyModel),
        typeof(ConfigurationStoreModel),
        typeof(ConfigurationStorePropertiesModel),
        typeof(ConfigurationStorePropertiesUpdateParametersModel),
        typeof(ConfigurationStoreUpdateParametersModel),
        typeof(EncryptionPropertiesModel),
        typeof(KeyVaultPropertiesModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointConnectionReferenceModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(RegenerateKeyParametersModel),
        typeof(SkuModel),
    };
}
