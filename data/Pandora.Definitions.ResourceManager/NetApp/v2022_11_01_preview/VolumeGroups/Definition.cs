using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01_preview.VolumeGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "VolumeGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByNetAppAccountOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ApplicationTypeConstant),
        typeof(AvsDataStoreConstant),
        typeof(ChownModeConstant),
        typeof(EnableSubvolumesConstant),
        typeof(EncryptionKeySourceConstant),
        typeof(EndpointTypeConstant),
        typeof(FileAccessLogsConstant),
        typeof(NetworkFeaturesConstant),
        typeof(ReplicationScheduleConstant),
        typeof(SecurityStyleConstant),
        typeof(ServiceLevelConstant),
        typeof(SmbAccessBasedEnumerationConstant),
        typeof(SmbNonBrowsableConstant),
        typeof(VolumeStorageToNetworkProximityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExportPolicyRuleModel),
        typeof(MountTargetPropertiesModel),
        typeof(PlacementKeyValuePairsModel),
        typeof(ReplicationObjectModel),
        typeof(VolumeBackupPropertiesModel),
        typeof(VolumeGroupModel),
        typeof(VolumeGroupDetailsModel),
        typeof(VolumeGroupListModel),
        typeof(VolumeGroupListPropertiesModel),
        typeof(VolumeGroupMetaDataModel),
        typeof(VolumeGroupPropertiesModel),
        typeof(VolumeGroupVolumePropertiesModel),
        typeof(VolumePropertiesModel),
        typeof(VolumePropertiesDataProtectionModel),
        typeof(VolumePropertiesExportPolicyModel),
        typeof(VolumeRelocationPropertiesModel),
        typeof(VolumeSnapshotPropertiesModel),
    };
}
