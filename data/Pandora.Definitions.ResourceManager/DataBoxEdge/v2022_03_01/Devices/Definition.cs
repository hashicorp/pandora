using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

internal class Definition : ResourceDefinition
{
    public string Name => "Devices";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateOrUpdateSecuritySettingsOperation(),
        new DeleteOperation(),
        new DownloadUpdatesOperation(),
        new GenerateCertificateOperation(),
        new GetOperation(),
        new GetExtendedInformationOperation(),
        new GetNetworkSettingsOperation(),
        new GetUpdateSummaryOperation(),
        new InstallUpdatesOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ScanForUpdatesOperation(),
        new UpdateOperation(),
        new UpdateExtendedInformationOperation(),
        new UploadCertificateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthenticationTypeConstant),
        typeof(ClusterWitnessTypeConstant),
        typeof(DataBoxEdgeDeviceKindConstant),
        typeof(DataBoxEdgeDeviceStatusConstant),
        typeof(DataResidencyTypeConstant),
        typeof(DeviceTypeConstant),
        typeof(EncryptionAlgorithmConstant),
        typeof(InstallRebootBehaviorConstant),
        typeof(InstallationImpactConstant),
        typeof(JobStatusConstant),
        typeof(KeyVaultSyncStatusConstant),
        typeof(MsiIdentityTypeConstant),
        typeof(NetworkAdapterDHCPStatusConstant),
        typeof(NetworkAdapterRDMAStatusConstant),
        typeof(NetworkAdapterStatusConstant),
        typeof(NetworkGroupConstant),
        typeof(ResourceMoveStatusConstant),
        typeof(RoleTypesConstant),
        typeof(SkuNameConstant),
        typeof(SkuTierConstant),
        typeof(SubscriptionStateConstant),
        typeof(UpdateOperationConstant),
        typeof(UpdateStatusConstant),
        typeof(UpdateTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AsymmetricEncryptedSecretModel),
        typeof(DataBoxEdgeDeviceModel),
        typeof(DataBoxEdgeDeviceExtendedInfoModel),
        typeof(DataBoxEdgeDeviceExtendedInfoPatchModel),
        typeof(DataBoxEdgeDeviceExtendedInfoPropertiesModel),
        typeof(DataBoxEdgeDevicePatchModel),
        typeof(DataBoxEdgeDevicePropertiesModel),
        typeof(DataBoxEdgeDevicePropertiesPatchModel),
        typeof(DataResidencyModel),
        typeof(EdgeProfileModel),
        typeof(EdgeProfilePatchModel),
        typeof(EdgeProfileSubscriptionModel),
        typeof(EdgeProfileSubscriptionPatchModel),
        typeof(GenerateCertResponseModel),
        typeof(IPv4ConfigModel),
        typeof(IPv6ConfigModel),
        typeof(NetworkAdapterModel),
        typeof(NetworkAdapterPositionModel),
        typeof(NetworkSettingsModel),
        typeof(NetworkSettingsPropertiesModel),
        typeof(RawCertificateDataModel),
        typeof(ResourceIdentityModel),
        typeof(ResourceMoveDetailsModel),
        typeof(SecretModel),
        typeof(SecuritySettingsModel),
        typeof(SecuritySettingsPropertiesModel),
        typeof(SkuModel),
        typeof(SubscriptionPropertiesModel),
        typeof(SubscriptionRegisteredFeaturesModel),
        typeof(UpdateDetailsModel),
        typeof(UpdateSummaryModel),
        typeof(UpdateSummaryPropertiesModel),
        typeof(UploadCertificateRequestModel),
        typeof(UploadCertificateResponseModel),
    };
}
