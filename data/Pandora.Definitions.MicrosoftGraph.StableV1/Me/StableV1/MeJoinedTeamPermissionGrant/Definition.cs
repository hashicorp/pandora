// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeJoinedTeamPermissionGrant;

internal class Definition : ResourceDefinition
{
    public string Name => "MeJoinedTeamPermissionGrant";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckMeJoinedTeamByIdPermissionGrantByIdMemberGroupOperation(),
        new CheckMeJoinedTeamByIdPermissionGrantByIdMemberObjectOperation(),
        new CreateMeJoinedTeamByIdPermissionGrantOperation(),
        new DeleteMeJoinedTeamByIdPermissionGrantByIdOperation(),
        new GetMeJoinedTeamByIdPermissionGrantByIdMemberGroupOperation(),
        new GetMeJoinedTeamByIdPermissionGrantByIdMemberObjectOperation(),
        new GetMeJoinedTeamByIdPermissionGrantByIdOperation(),
        new GetMeJoinedTeamByIdPermissionGrantCountOperation(),
        new GetMeJoinedTeamByIdPermissionGrantsAvailableExtensionPropertiesOperation(),
        new GetMeJoinedTeamByIdPermissionGrantsByIdsOperation(),
        new ListMeJoinedTeamByIdPermissionGrantsOperation(),
        new RestoreMeJoinedTeamByIdPermissionGrantByIdOperation(),
        new UpdateMeJoinedTeamByIdPermissionGrantByIdOperation(),
        new ValidateMeJoinedTeamByIdPermissionGrantsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckMeJoinedTeamByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(CheckMeJoinedTeamByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetMeJoinedTeamByIdPermissionGrantByIdMemberGroupRequestModel),
        typeof(GetMeJoinedTeamByIdPermissionGrantByIdMemberObjectRequestModel),
        typeof(GetMeJoinedTeamByIdPermissionGrantsAvailableExtensionPropertiesRequestModel),
        typeof(GetMeJoinedTeamByIdPermissionGrantsByIdsRequestModel),
        typeof(ValidateMeJoinedTeamByIdPermissionGrantsPropertyRequestModel)
    };
}
