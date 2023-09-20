// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeamPermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamPermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckGroupByIdTeamPermissionGrantByIdMemberGroupOperation(),
        new CheckGroupByIdTeamPermissionGrantByIdMemberObjectOperation(),
        new CreateGroupByIdTeamPermissionGrantOperation(),
        new DeleteGroupByIdTeamPermissionGrantByIdOperation(),
        new GetGroupByIdTeamPermissionGrantByIdMemberGroupOperation(),
        new GetGroupByIdTeamPermissionGrantByIdMemberObjectOperation(),
        new GetGroupByIdTeamPermissionGrantByIdOperation(),
        new GetGroupByIdTeamPermissionGrantCountOperation(),
        new GetGroupByIdTeamPermissionGrantsAvailableExtensionPropertiesOperation(),
        new GetGroupByIdTeamPermissionGrantsByIdsOperation(),
        new ListGroupByIdTeamPermissionGrantsOperation(),
        new RestoreGroupByIdTeamPermissionGrantByIdOperation(),
        new UpdateGroupByIdTeamPermissionGrantByIdOperation(),
        new ValidateGroupByIdTeamPermissionGrantsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckGroupByIdTeamPermissionGrantByIdMemberGroupRequestModel),
        typeof(CheckGroupByIdTeamPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetGroupByIdTeamPermissionGrantByIdMemberGroupRequestModel),
        typeof(GetGroupByIdTeamPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetGroupByIdTeamPermissionGrantsAvailableExtensionPropertiesRequestModel),
        typeof(GetGroupByIdTeamPermissionGrantsByIdsRequestModel),
        typeof(ValidateGroupByIdTeamPermissionGrantsPropertyRequestModel)
    };
}
