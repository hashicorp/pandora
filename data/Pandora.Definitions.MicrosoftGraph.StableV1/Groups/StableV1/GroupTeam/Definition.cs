// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupTeam;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeam";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamArchiveOperation(),
        new CreateGroupByIdTeamCloneOperation(),
        new CreateGroupByIdTeamCompleteMigrationOperation(),
        new CreateGroupByIdTeamSendActivityNotificationOperation(),
        new CreateGroupByIdTeamUnarchiveOperation(),
        new CreateUpdateGroupByIdTeamOperation(),
        new DeleteGroupByIdTeamOperation(),
        new GetGroupByIdTeamOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateGroupByIdTeamCloneRequestPartsToCloneConstant),
        typeof(CreateGroupByIdTeamCloneRequestVisibilityConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdTeamArchiveRequestModel),
        typeof(CreateGroupByIdTeamCloneRequestModel),
        typeof(CreateGroupByIdTeamSendActivityNotificationRequestModel)
    };
}
