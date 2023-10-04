using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2023_01_01.Snapshots;

internal class Definition : ResourceDefinition
{
    public string Name => "Snapshots";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new VolumeSnapshotsCreateOperation(),
        new VolumeSnapshotsDeleteOperation(),
        new VolumeSnapshotsGetOperation(),
        new VolumeSnapshotsListByVolumeGroupOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStatesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SnapshotModel),
        typeof(SnapshotCreationDataModel),
        typeof(SnapshotPropertiesModel),
    };
}
