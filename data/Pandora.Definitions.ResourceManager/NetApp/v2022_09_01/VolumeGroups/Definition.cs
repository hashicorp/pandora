using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.VolumeGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "VolumeGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new VolumeGroupsCreateOperation(),
        new VolumeGroupsDeleteOperation(),
        new VolumeGroupsGetOperation(),
        new VolumeGroupsListByNetAppAccountOperation(),
    };
}
