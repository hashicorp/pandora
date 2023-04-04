using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Databricks.v2022_04_01_preview.Workspaces;

internal class Definition : ResourceDefinition
{
    public string Name => "Workspaces";
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
        typeof(CustomParameterTypeConstant),
        typeof(EncryptionKeySourceConstant),
        typeof(KeySourceConstant),
        typeof(PrivateEndpointConnectionProvisioningStateConstant),
        typeof(PrivateLinkServiceConnectionStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(RequiredNsgRulesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreatedByModel),
        typeof(EncryptionModel),
        typeof(EncryptionEntitiesDefinitionModel),
        typeof(EncryptionV2Model),
        typeof(EncryptionV2KeyVaultPropertiesModel),
        typeof(ManagedDiskEncryptionModel),
        typeof(ManagedDiskEncryptionKeyVaultPropertiesModel),
        typeof(ManagedIdentityConfigurationModel),
        typeof(PrivateEndpointModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(SkuModel),
        typeof(WorkspaceModel),
        typeof(WorkspaceCustomBooleanParameterModel),
        typeof(WorkspaceCustomObjectParameterModel),
        typeof(WorkspaceCustomParametersModel),
        typeof(WorkspaceCustomStringParameterModel),
        typeof(WorkspaceEncryptionParameterModel),
        typeof(WorkspacePropertiesModel),
        typeof(WorkspacePropertiesEncryptionModel),
        typeof(WorkspaceProviderAuthorizationModel),
        typeof(WorkspaceUpdateModel),
    };
}
