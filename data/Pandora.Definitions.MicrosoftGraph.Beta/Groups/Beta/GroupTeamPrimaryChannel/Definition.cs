// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamPrimaryChannel;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamPrimaryChannel";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamPrimaryChannelCompleteMigrationOperation(),
        new DeleteGroupByIdTeamPrimaryChannelOperation(),
        new GetGroupByIdTeamPrimaryChannelOperation(),
        new ProvisionGroupByIdTeamPrimaryChannelEmailOperation(),
        new RemoveGroupByIdTeamPrimaryChannelEmailOperation(),
        new UpdateGroupByIdTeamPrimaryChannelOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
