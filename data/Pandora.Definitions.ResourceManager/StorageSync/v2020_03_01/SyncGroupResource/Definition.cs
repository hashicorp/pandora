using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.SyncGroupResource;

internal class Definition : ResourceDefinition
{
    public string Name => "SyncGroupResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SyncGroupsCreateOperation(),
        new SyncGroupsDeleteOperation(),
        new SyncGroupsGetOperation(),
        new SyncGroupsListByStorageSyncServiceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SyncGroupModel),
        typeof(SyncGroupArrayModel),
        typeof(SyncGroupCreateParametersModel),
        typeof(SyncGroupPropertiesModel),
    };
}
