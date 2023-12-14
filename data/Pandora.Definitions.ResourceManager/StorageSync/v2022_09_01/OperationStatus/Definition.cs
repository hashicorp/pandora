using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.OperationStatus;

internal class Definition : ResourceDefinition
{
    public string Name => "OperationStatus";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new LocationOperationStatusOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LocationOperationStatusModel),
        typeof(StorageSyncApiErrorModel),
        typeof(StorageSyncErrorDetailsModel),
        typeof(StorageSyncInnerErrorDetailsModel),
    };
}
