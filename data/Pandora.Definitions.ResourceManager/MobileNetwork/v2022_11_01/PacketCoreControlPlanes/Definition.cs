using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.PacketCoreControlPlanes;

internal class Definition : ResourceDefinition
{
    public string Name => "PacketCoreControlPlanes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthenticationTypeConstant),
        typeof(BillingSkuConstant),
        typeof(CertificateProvisioningStateConstant),
        typeof(CoreNetworkTypeConstant),
        typeof(InstallationStateConstant),
        typeof(PlatformTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AsyncOperationIdModel),
        typeof(AzureStackEdgeDeviceResourceIdModel),
        typeof(AzureStackHCIClusterResourceIdModel),
        typeof(CertificateProvisioningModel),
        typeof(ConnectedClusterResourceIdModel),
        typeof(CustomLocationResourceIdModel),
        typeof(HTTPSServerCertificateModel),
        typeof(InstallationModel),
        typeof(InterfacePropertiesModel),
        typeof(LocalDiagnosticsAccessConfigurationModel),
        typeof(PacketCoreControlPlaneModel),
        typeof(PacketCoreControlPlanePropertiesFormatModel),
        typeof(PlatformConfigurationModel),
        typeof(SiteResourceIdModel),
    };
}
