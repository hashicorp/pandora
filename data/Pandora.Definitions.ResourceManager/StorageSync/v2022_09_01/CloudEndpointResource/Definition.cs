using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.CloudEndpointResource;

internal class Definition : ResourceDefinition
{
    public string Name => "CloudEndpointResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CloudEndpointsAfsShareMetadataCertificatePublicKeysOperation(),
        new CloudEndpointsCreateOperation(),
        new CloudEndpointsDeleteOperation(),
        new CloudEndpointsGetOperation(),
        new CloudEndpointsListBySyncGroupOperation(),
        new CloudEndpointsPostBackupOperation(),
        new CloudEndpointsPostRestoreOperation(),
        new CloudEndpointsPreBackupOperation(),
        new CloudEndpointsPreRestoreOperation(),
        new CloudEndpointsTriggerChangeDetectionOperation(),
        new CloudEndpointsrestoreheartbeatOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ChangeDetectionModeConstant),
        typeof(CloudEndpointChangeEnumerationActivityStateConstant),
        typeof(CloudEndpointChangeEnumerationTotalCountsStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupRequestModel),
        typeof(CloudEndpointModel),
        typeof(CloudEndpointAfsShareMetadataCertificatePublicKeysModel),
        typeof(CloudEndpointArrayModel),
        typeof(CloudEndpointChangeEnumerationActivityModel),
        typeof(CloudEndpointChangeEnumerationStatusModel),
        typeof(CloudEndpointCreateParametersModel),
        typeof(CloudEndpointCreateParametersPropertiesModel),
        typeof(CloudEndpointLastChangeEnumerationStatusModel),
        typeof(CloudEndpointPropertiesModel),
        typeof(PostBackupResponseModel),
        typeof(PostBackupResponsePropertiesModel),
        typeof(PostRestoreRequestModel),
        typeof(PreRestoreRequestModel),
        typeof(RestoreFileSpecModel),
        typeof(TriggerChangeDetectionParametersModel),
    };
}
