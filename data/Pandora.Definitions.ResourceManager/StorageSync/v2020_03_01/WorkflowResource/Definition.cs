using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.WorkflowResource;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkflowResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new WorkflowsAbortOperation(),
        new WorkflowsGetOperation(),
        new WorkflowsListByStorageSyncServiceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OperationDirectionConstant),
        typeof(WorkflowStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(WorkflowModel),
        typeof(WorkflowArrayModel),
        typeof(WorkflowPropertiesModel),
    };
}
