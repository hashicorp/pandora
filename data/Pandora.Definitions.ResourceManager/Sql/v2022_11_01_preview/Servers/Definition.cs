using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.Servers;

internal class Definition : ResourceDefinition
{
    public string Name => "Servers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ImportDatabaseOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RefreshStatusOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AdministratorTypeConstant),
        typeof(CheckNameAvailabilityReasonConstant),
        typeof(CheckNameAvailabilityResourceTypeConstant),
        typeof(ExternalGovernanceStatusConstant),
        typeof(PrincipalTypeConstant),
        typeof(PrivateEndpointProvisioningStateConstant),
        typeof(PrivateLinkServiceConnectionStateActionsRequireConstant),
        typeof(PrivateLinkServiceConnectionStateStatusConstant),
        typeof(ServerNetworkAccessFlagConstant),
        typeof(ServerPublicNetworkAccessFlagConstant),
        typeof(ServerWorkspaceFeatureConstant),
        typeof(StorageKeyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResponseModel),
        typeof(ImportExportOperationResultModel),
        typeof(ImportExportOperationResultPropertiesModel),
        typeof(ImportNewDatabaseDefinitionModel),
        typeof(NetworkIsolationSettingsModel),
        typeof(PrivateEndpointConnectionPropertiesModel),
        typeof(PrivateEndpointConnectionRequestStatusModel),
        typeof(PrivateEndpointPropertyModel),
        typeof(PrivateLinkServiceConnectionStatePropertyModel),
        typeof(RefreshExternalGovernanceStatusOperationResultModel),
        typeof(RefreshExternalGovernanceStatusOperationResultPropertiesModel),
        typeof(ServerModel),
        typeof(ServerExternalAdministratorModel),
        typeof(ServerPrivateEndpointConnectionModel),
        typeof(ServerPropertiesModel),
        typeof(ServerUpdateModel),
    };
}
