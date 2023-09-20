// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupTeamPrimaryChannelMessageHostedContent;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupTeamPrimaryChannelMessageHostedContent";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdTeamPrimaryChannelMessageByIdHostedContentOperation(),
        new CreateUpdateGroupByIdTeamPrimaryChannelMessageByIdHostedContentByIdValueOperation(),
        new DeleteGroupByIdTeamPrimaryChannelMessageByIdHostedContentByIdOperation(),
        new GetGroupByIdTeamPrimaryChannelMessageByIdHostedContentByIdOperation(),
        new GetGroupByIdTeamPrimaryChannelMessageByIdHostedContentByIdValueOperation(),
        new GetGroupByIdTeamPrimaryChannelMessageByIdHostedContentCountOperation(),
        new ListGroupByIdTeamPrimaryChannelMessageByIdHostedContentsOperation(),
        new UpdateGroupByIdTeamPrimaryChannelMessageByIdHostedContentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
