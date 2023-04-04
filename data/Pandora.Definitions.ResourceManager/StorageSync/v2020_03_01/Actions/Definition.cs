using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.Actions;

internal class Definition : ResourceDefinition
{
    public string Name => "Actions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CloudEndpointsPostBackupOperation(),
        new CloudEndpointsPostRestoreOperation(),
        new CloudEndpointsPreBackupOperation(),
        new CloudEndpointsPreRestoreOperation(),
        new CloudEndpointsTriggerChangeDetectionOperation(),
        new CloudEndpointsrestoreheartbeatOperation(),
        new RegisteredServerstriggerRolloverOperation(),
        new ServerEndpointsrecallActionOperation(),
        new WorkflowsAbortOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ChangeDetectionModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupRequestModel),
        typeof(PostBackupResponseModel),
        typeof(PostBackupResponsePropertiesModel),
        typeof(PostRestoreRequestModel),
        typeof(PreRestoreRequestModel),
        typeof(RecallActionParametersModel),
        typeof(RestoreFileSpecModel),
        typeof(TriggerChangeDetectionParametersModel),
        typeof(TriggerRolloverRequestModel),
    };
}
