using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;

internal class Definition : ResourceDefinition
{
    public string Name => "ServerEndpointResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServerEndpointsCreateOperation(),
        new ServerEndpointsDeleteOperation(),
        new ServerEndpointsGetOperation(),
        new ServerEndpointsListBySyncGroupOperation(),
        new ServerEndpointsUpdateOperation(),
        new ServerEndpointsrecallActionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FeatureStatusConstant),
        typeof(InitialDownloadPolicyConstant),
        typeof(LocalCacheModeConstant),
        typeof(ServerEndpointCloudTieringHealthStateConstant),
        typeof(ServerEndpointOfflineDataTransferStateConstant),
        typeof(ServerEndpointSyncActivityStateConstant),
        typeof(ServerEndpointSyncHealthStateConstant),
        typeof(ServerEndpointSyncModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CloudTieringCachePerformanceModel),
        typeof(CloudTieringDatePolicyStatusModel),
        typeof(CloudTieringFilesNotTieringModel),
        typeof(CloudTieringSpaceSavingsModel),
        typeof(CloudTieringVolumeFreeSpacePolicyStatusModel),
        typeof(FilesNotTieringErrorModel),
        typeof(RecallActionParametersModel),
        typeof(ServerEndpointModel),
        typeof(ServerEndpointArrayModel),
        typeof(ServerEndpointCloudTieringStatusModel),
        typeof(ServerEndpointCreateParametersModel),
        typeof(ServerEndpointCreateParametersPropertiesModel),
        typeof(ServerEndpointFilesNotSyncingErrorModel),
        typeof(ServerEndpointPropertiesModel),
        typeof(ServerEndpointRecallErrorModel),
        typeof(ServerEndpointRecallStatusModel),
        typeof(ServerEndpointSyncActivityStatusModel),
        typeof(ServerEndpointSyncSessionStatusModel),
        typeof(ServerEndpointSyncStatusModel),
        typeof(ServerEndpointUpdateParametersModel),
        typeof(ServerEndpointUpdatePropertiesModel),
    };
}
