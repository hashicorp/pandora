using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2023_08_15.Clusters;

internal class Definition : ResourceDefinition
{
    public string Name => "Clusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddLanguageExtensionsOperation(),
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DetachFollowerDatabasesOperation(),
        new DiagnoseVirtualNetworkOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListFollowerDatabasesOperation(),
        new ListLanguageExtensionsOperation(),
        new ListSkusByResourceOperation(),
        new MigrateOperation(),
        new RemoveLanguageExtensionsOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AzureScaleTypeConstant),
        typeof(AzureSkuNameConstant),
        typeof(AzureSkuTierConstant),
        typeof(ClusterNetworkAccessFlagConstant),
        typeof(ClusterTypeConstant),
        typeof(DatabaseShareOriginConstant),
        typeof(EngineTypeConstant),
        typeof(LanguageExtensionImageNameConstant),
        typeof(LanguageExtensionNameConstant),
        typeof(MigrationClusterRoleConstant),
        typeof(ProvisioningStateConstant),
        typeof(PublicIPTypeConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(ReasonConstant),
        typeof(StateConstant),
        typeof(VnetStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AcceptedAudiencesModel),
        typeof(AzureCapacityModel),
        typeof(AzureResourceSkuModel),
        typeof(AzureSkuModel),
        typeof(CheckNameResultModel),
        typeof(ClusterModel),
        typeof(ClusterCheckNameRequestModel),
        typeof(ClusterListResultModel),
        typeof(ClusterMigrateRequestModel),
        typeof(ClusterPropertiesModel),
        typeof(ClusterUpdateModel),
        typeof(DiagnoseVirtualNetworkResultModel),
        typeof(FollowerDatabaseDefinitionModel),
        typeof(FollowerDatabaseListResultModel),
        typeof(KeyVaultPropertiesModel),
        typeof(LanguageExtensionModel),
        typeof(LanguageExtensionsListModel),
        typeof(ListResourceSkusResultModel),
        typeof(MigrationClusterPropertiesModel),
        typeof(OptimizedAutoscaleModel),
        typeof(PrivateEndpointConnectionModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointPropertyModel),
        typeof(PrivateLinkServiceConnectionStatePropertyModel),
        typeof(TableLevelSharingPropertiesModel),
        typeof(TrustedExternalTenantModel),
        typeof(VirtualNetworkConfigurationModel),
    };
}
