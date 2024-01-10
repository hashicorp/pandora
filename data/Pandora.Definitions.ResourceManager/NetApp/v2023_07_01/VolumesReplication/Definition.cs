using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.VolumesReplication;

internal class Definition : ResourceDefinition
{
    public string Name => "VolumesReplication";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new VolumesAuthorizeReplicationOperation(),
        new VolumesBreakReplicationOperation(),
        new VolumesDeleteReplicationOperation(),
        new VolumesListReplicationsOperation(),
        new VolumesReInitializeReplicationOperation(),
        new VolumesReestablishReplicationOperation(),
        new VolumesReplicationStatusOperation(),
        new VolumesResyncReplicationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EndpointTypeConstant),
        typeof(MirrorStateConstant),
        typeof(RelationshipStatusConstant),
        typeof(ReplicationScheduleConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthorizeRequestModel),
        typeof(BreakReplicationRequestModel),
        typeof(ListReplicationsModel),
        typeof(ReestablishReplicationRequestModel),
        typeof(ReplicationModel),
        typeof(ReplicationStatusModel),
    };
}
