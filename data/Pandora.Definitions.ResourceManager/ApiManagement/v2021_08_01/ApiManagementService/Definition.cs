using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.ApiManagementService;

internal class Definition : ResourceDefinition
{
    public string Name => "ApiManagementService";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ApplyNetworkConfigurationUpdatesOperation(),
        new BackupOperation(),
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetDomainOwnershipIdentifierOperation(),
        new GetSsoTokenOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new RestoreOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessIdNameConstant),
        typeof(AccessTypeConstant),
        typeof(CertificateSourceConstant),
        typeof(CertificateStatusConstant),
        typeof(HostnameTypeConstant),
        typeof(IdentityProviderTypeConstant),
        typeof(NameAvailabilityReasonConstant),
        typeof(NotificationNameConstant),
        typeof(PlatformVersionConstant),
        typeof(PrivateEndpointServiceConnectionStatusConstant),
        typeof(PublicNetworkAccessConstant),
        typeof(SkuTypeConstant),
        typeof(StoreNameConstant),
        typeof(TemplateNameConstant),
        typeof(VirtualNetworkTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdditionalLocationModel),
        typeof(ApiManagementServiceApplyNetworkConfigurationParametersModel),
        typeof(ApiManagementServiceBackupRestoreParametersModel),
        typeof(ApiManagementServiceCheckNameAvailabilityParametersModel),
        typeof(ApiManagementServiceGetDomainOwnershipIdentifierResultModel),
        typeof(ApiManagementServiceGetSsoTokenResultModel),
        typeof(ApiManagementServiceNameAvailabilityResultModel),
        typeof(ApiManagementServicePropertiesModel),
        typeof(ApiManagementServiceResourceModel),
        typeof(ApiManagementServiceSkuPropertiesModel),
        typeof(ApiManagementServiceUpdateParametersModel),
        typeof(ApiManagementServiceUpdatePropertiesModel),
        typeof(ApiVersionConstraintModel),
        typeof(ArmIdWrapperModel),
        typeof(CertificateConfigurationModel),
        typeof(CertificateInformationModel),
        typeof(HostnameConfigurationModel),
        typeof(PrivateEndpointConnectionWrapperPropertiesModel),
        typeof(PrivateLinkServiceConnectionStateModel),
        typeof(RemotePrivateEndpointConnectionWrapperModel),
        typeof(VirtualNetworkConfigurationModel),
    };
}
